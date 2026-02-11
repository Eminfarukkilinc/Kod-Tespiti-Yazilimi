using Microsoft.ML.Data;

namespace KodTespitiYazilimi
{
    
    public class KodVerisi
    {
        [LoadColumn(0)]
        public string KodIcerigi { get; set; }

        [LoadColumn(1)]
        public bool Etiket { get; set; }
    }

    //Model 1 ve 2 İçin Tekil Olasılık
    public class BinaryTahmin
    {
        [ColumnName("PredictedLabel")]
        public bool Tahmin { get; set; }

        [ColumnName("Probability")]
        public float Olasilik { get; set; }
    }

    //Model 3 (Naive Bayes)
    public class NaiveBayesTahmin
    {
        
        [ColumnName("PredictedLabel")]
        public bool Tahmin { get; set; }

        
        [ColumnName("Score")]
        public float[] Skorlar { get; set; }
    }
}