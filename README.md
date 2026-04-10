# Kod-Tespiti-Yazilimi (AI vs. Human Code Detector)

Bu repo, sistemin ana bileşenidir. Öncelikli amacı, kendisine verilen bir kod bloğunun bir insan tarafından mı yoksa bir yapay zeka tarafından mı yazıldığını analiz edip tespit etmektir. 

Sistem, karar verebilmek için 3 farklı makine öğrenmesi modeli eğitmektedir. Bu modellerin eğitimi, `Veri-Toplayici-Bot` ve `Ai-Veri-Uretici` alt projelerinden elde edilen veri setleri kullanılarak gerçekleştirilir.

## 🔗 Alt Projeler (Veri Sağlayıcılar)
Bu ana projenin çalışabilmesi için aşağıdaki iki araçtan elde edilen verilere ihtiyaç vardır:
* [Veri-Toplayici-Bot](https://github.com/Eminfarukkilinc/Veri-Toplayici-Bot): İnsan yapımı referans kodları toplar.
* [Ai-Veri-Uretici](https://github.com/Eminfarukkilinc/Ai-Veri-Uretici): İnsan kodlarını AI formatına çevirerek sentetik veri oluşturur.

## ⚙️ Gereksinimler

Bu ana makine öğrenmesi hattının (pipeline) çalışabilmesi ve modellerin eğitilebilmesi için aşağıdaki veri setleri projenin ilgili dizininde hazır bulunmalıdır:

1.  **İnsan Kodu Veri Seti:** `human_data.csv` (Veri-Toplayici-Bot çıktısı)
2.  **Yapay Zeka Kodu Veri Seti:** `ai_data.csv` (Ai-Veri-Uretici çıktısı)

*Not: Bu repoda herhangi bir API anahtarına (GitHub veya Gemini) ihtiyaç yoktur; işlemler tamamen yerel olarak toplanmış veriler üzerinden gerçekleşir.*

## 🚀 Kullanım

1. Gerekli iki veri setini de toplayıcı botlar aracılığıyla oluşturun ve bu projenin içerisindeki ilgili klasöre yerleştirin.
2. Gerekli kütüphaneleri ve bağımlılıkları (requirements) kurun.
3. Model eğitim scriptini çalıştırın.
4. Eğitim tamamlandıktan sonra, tespit aracına dilediğiniz kod bloğunu vererek test edebilirsiniz.
