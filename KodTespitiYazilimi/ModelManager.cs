using Microsoft.ML;
using System;
using System.Linq;
using System.IO;

namespace KodTespitiYazilimi
{
    public class ModelManager
    {
        private static MLContext mlContext = new MLContext();
        private ITransformer model1, model2, model3;

        public void ModelleriEgit(string csvDosyaYolu)
        {
            
            string yol1 = "trained_sdca.zip";
            string yol2 = "trained_fasttree.zip";
            string yol3 = "trained_naivebayes.zip";

            //Eğer modeller daha önce kaydedilmişse tekrar eğitmek yerine direkt yükle
            if (File.Exists(yol1) && File.Exists(yol2) && File.Exists(yol3))
            {
                DataViewSchema schema;
                model1 = mlContext.Model.Load(yol1, out schema);
                model2 = mlContext.Model.Load(yol2, out schema);
                model3 = mlContext.Model.Load(yol3, out schema);
                return; 
            }
            

            
            IDataView veri = mlContext.Data.LoadFromTextFile<KodVerisi>(path: csvDosyaYolu, hasHeader: true, separatorChar: '|');
            var veriSeti = mlContext.Data.TrainTestSplit(veri, testFraction: 0.2);

            var pipelineBasi = mlContext.Transforms.Text.FeaturizeText("Features", nameof(KodVerisi.KodIcerigi))
                .Append(mlContext.Transforms.CopyColumns("Label", nameof(KodVerisi.Etiket)));

            //Model 1 (SDCA)
            var trainer1 = mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features");
            model1 = pipelineBasi.Append(trainer1).Fit(veriSeti.TrainSet);

            //Model 2 (FastTree)
            var trainer2 = mlContext.BinaryClassification.Trainers.FastTree(labelColumnName: "Label", featureColumnName: "Features");
            model2 = pipelineBasi.Append(trainer2).Fit(veriSeti.TrainSet);

            //Model 3 (Naive Bayes)
            var pipeline3 = pipelineBasi
                .Append(mlContext.Transforms.Conversion.MapValueToKey("Label"))
                .Append(mlContext.MulticlassClassification.Trainers.NaiveBayes(labelColumnName: "Label", featureColumnName: "Features"))
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            model3 = pipeline3.Fit(veriSeti.TrainSet);

            //EĞİTİLEN MODELLERİ KAYDET
            
            mlContext.Model.Save(model1, veriSeti.TrainSet.Schema, yol1);
            mlContext.Model.Save(model2, veriSeti.TrainSet.Schema, yol2);
            mlContext.Model.Save(model3, veriSeti.TrainSet.Schema, yol3);
            
        }

        //tahmin
        public (float sonuc1, float sonuc2, float sonuc3) TahminEt(string kod)
        {
            var tekilVeri = new KodVerisi { KodIcerigi = kod };

            //SDCA
            var engine1 = mlContext.Model.CreatePredictionEngine<KodVerisi, BinaryTahmin>(model1);
            float oran1 = engine1.Predict(tekilVeri).Olasilik;

            //FastTree
            var engine2 = mlContext.Model.CreatePredictionEngine<KodVerisi, BinaryTahmin>(model2);
            float oran2 = engine2.Predict(tekilVeri).Olasilik;

            //Naive Bayes
            var engine3 = mlContext.Model.CreatePredictionEngine<KodVerisi, NaiveBayesTahmin>(model3);
            var tahmin3 = engine3.Predict(tekilVeri);

            float oran3 = 0.5f; 

            if (tahmin3.Skorlar != null && tahmin3.Skorlar.Length >= 2)
            {
                
                float scoreHuman = tahmin3.Skorlar[0];
                float scoreAI = tahmin3.Skorlar[1];

                
                float sicaklikKatsayisi = 1000.0f;

                float maxScore = Math.Max(scoreHuman, scoreAI);

                
                double expHuman = Math.Exp((scoreHuman - maxScore) / sicaklikKatsayisi);
                double expAI = Math.Exp((scoreAI - maxScore) / sicaklikKatsayisi);

                double toplam = expHuman + expAI;

                oran3 = (float)(expAI / toplam);
            }

            return (oran1, oran2, oran3);
        }
    }
}