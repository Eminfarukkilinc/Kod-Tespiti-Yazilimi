using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KodTespitiYazilimi
{
    public partial class frmAnalizEkrani : Form
    {
        //Yapay Zeka Yöneticimiz
        ModelManager yonetici = new ModelManager();
        string birlestirilmisVeriYolu = "final_data.csv";
        bool modelHazirMi = false;

        public frmAnalizEkrani()
        {
            InitializeComponent();
        }

        private void frmAnalizEkrani_Load(object sender, EventArgs e)
        {
            
            lblSonuc.Text = "Veriler Hazýrlanýyor...";
            lblSonuc.ForeColor = Color.Orange;

            
            Task.Run(() =>
            {
                VerileriBirlestirVeEgit();
            });
        }

        private void VerileriBirlestirVeEgit()
        {
            try
            {
                //Dosyalarý Kontrol Et
                string insanDosyasi = "human_data.csv";
                string aiDosyasi = "ai_data.csv";

                if (!File.Exists(insanDosyasi) || !File.Exists(aiDosyasi))
                {
                    Invoke(new Action(() => {
                        lblSonuc.Text = "HATA: Veri dosyalarý (csv) bulunamadý!";
                        lblSonuc.ForeColor = Color.Red;
                        MessageBox.Show("Lütfen 'human_data.csv' ve 'ai_data.csv' dosyalarýný klasöre atýn.");
                    }));
                    return;
                }

                //VERÝ TEMÝZLEME VE BÝRLEÞTÝRME

                List<string> temizlenmisSatirlar = new List<string>();

               
                temizlenmisSatirlar.Add("KodIcerigi|Etiket");

                
                void DosyayiTemizleVeEkle(string dosyaYolu, bool isAI)
                {
                    var hamSatirlar = File.ReadAllLines(dosyaYolu).Skip(1); 

                    foreach (var satir in hamSatirlar)
                    {
                        
                        if (string.IsNullOrWhiteSpace(satir)) continue;

                        if (satir.Trim().Length < 5) continue;

                       
                        string temizSatir = satir.Replace("|", " ");

                        
                        

                        
                        temizlenmisSatirlar.Add(temizSatir);
                    }
                }

                
                DosyayiTemizleVeEkle(insanDosyasi, false);
                DosyayiTemizleVeEkle(aiDosyasi, true);

                //veriyi kaydet
                File.WriteAllLines(birlestirilmisVeriYolu, temizlenmisSatirlar);

                

                
                Invoke(new Action(() => lblSonuc.Text = "Yapay Zeka Eðitiliyor... (Bekleyin)"));

                
                yonetici.ModelleriEgit(birlestirilmisVeriYolu);

                
                modelHazirMi = true;
                Invoke(new Action(() => {
                    lblSonuc.Text = "SÝSTEM HAZIR. Kodunuzu yapýþtýrýn.";
                    lblSonuc.ForeColor = Color.Green;
                }));
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => {
                    lblSonuc.Text = "Eðitim Hatasý!";
                    MessageBox.Show("Hata: " + ex.Message);
                }));
            }
        }

        private void btnAnaliz_Click(object sender, EventArgs e)
        {
            if (!modelHazirMi) { MessageBox.Show("Model bekleniyor..."); return; }

            //Tahminleri al
            var sonuclar = yonetici.TahminEt(rtbKod.Text);

            //PUANLAMA VE DÜZELTMELER

            //1. SDCA
            int skor1 = (int)(sonuclar.sonuc1 * 100);

            //2. FastTree
            int skor2 = (int)(sonuclar.sonuc2 * 100);

            //3. Naive Bayes
            int skor3 = (int)(sonuclar.sonuc3 * 100);

            //PROGRESS BAR KORUMASI (0-100 arasý tut)
            skor1 = Math.Max(0, Math.Min(100, skor1));
            skor2 = Math.Max(0, Math.Min(100, skor2));
            skor3 = Math.Max(0, Math.Min(100, skor3));

            //Görselleþtirme
            progressBar1.Value = skor1;
            label1.Text = $"Algoritma 1 (SDCA): %{skor1}";

            progressBar2.Value = skor2;
            label2.Text = $"Algoritma 2 (FastTree): %{skor2}";

            progressBar3.Value = skor3;
            
            label3.Text = $"Algoritma 3 (NaiveBayes): %{skor3}";

            //ORTALAMA HESABI (3 Algoritma Dahil)

            double ortalama = (skor1 + skor2 + skor3) / 3.0;

            if (ortalama > 50)
            {
                lblSonuc.Text = $"SONUÇ: YAPAY ZEKA (%{ortalama:0.0})";
                lblSonuc.ForeColor = Color.Red;
            }
            else
            {
                lblSonuc.Text = $"SONUÇ: ÝNSAN (%{100 - ortalama:0.0})";
                lblSonuc.ForeColor = Color.Blue;
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}