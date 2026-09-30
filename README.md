# Rugby Scoreboard

Rugby Union maçları için Türkçe, çevrimdışı skor yönetim uygulaması. Yönetici panelinden skor, saat ve kartlar kontrol edilir; seyirci ekranı aynı bilgisayarın ikinci monitöründe veya bağlı LED ekranda gösterilebilir.

Uygulama HTML, CSS ve JavaScript ile hazırlanmıştır. Windows EXE, arayüz dosyalarını içinde taşır ve varsayılan tarayıcıda açar. Sunucu, internet bağlantısı veya ağ üzerinden paylaşım kullanmaz.

## Özellikler

- İki takım için düzenlenebilir isimler, organizasyon ve saha bilgileri.
- Try **+5**, conversion **+2**, penaltı golü **+3**, drop goal **+3**, penalty try **+7**.
- Tüm maç aşamalarında serbest skor girişi; conversion için önce try girme zorunluluğu yoktur.
- **Son sayıyı iptal et:** iki takım arasındaki en son skor girişini geri alır. Saat ve kartlar korunur. Tekrar basıldığında önceki kalan sayı iptal edilir.
- Maç saati, devre arası, ikinci devre, uzatma ve maç sonu yönetimi.
- Oyuncu numarasıyla sarı/kırmızı kart ekleme ve manuel kaldırma. Sarı kartta süre sayacı bulunmaz.
- LED ekran için büyük yazılı seyirci görünümü ve skor eklendiğinde takım alanında parlama / +puan animasyonu.
- Maç akışı, son işlemi geri alma ve JSON maç kaydı indirme.

Puanlama Rugby Union içindir. Uygulama bir hakem karar sistemi değildir; skor ve kart girişleri operatör tarafından manuel yönetilir.

## Çalıştırma

### Windows EXE

1. `RugbyScoreboard.exe` dosyasını çalıştırın.
2. Yönetici paneli varsayılan tarayıcıda açılır.
3. **Seyirci ekranı** düğmesine basın.
4. Açılan pencereyi ikinci monitöre / LED ekrana taşıyın. Tam ekran için **F11** kullanın.

Yalnızca EXE dosyasını başka bilgisayara kopyalamak yeterlidir. `Baslat.cmd`, yanında bulunan EXE'yi açan isteğe bağlı bir kısayoldur.

Windows'ta .NET Framework 4.x ve güncel bir tarayıcı gerekir. Başlatıcı arayüz dosyalarını şu konuma çıkarır:

```text
%LOCALAPPDATA%\RugbyScoreboard\LocalApp
```

### Kaynak dosyalarla

Depoyu indirdikten sonra `index.html` dosyasını tarayıcıda açın. Bu kullanım için EXE derlemek gerekmez. `index.html`, `app.js` ve `style.css` aynı klasörde kalmalıdır.

## Açılış ve veri davranışı

**EXE veya yönetici sayfası her açıldığında eski maç verileri temizlenir. Yönetici sayfasını yenilemek de maçı sıfırlar.** Takım isimleri, organizasyon, saha, skorlar, saat, kartlar ve maç akışı başlangıç değerlerine döner.

- Seyirci ekranını açmak veya yenilemek mevcut maçı sıfırlamaz.
- Tarayıcının yerel depolaması ve `BroadcastChannel`, aynı bilgisayardaki açık yönetici / seyirci pencerelerini eşitlemek için kullanılır.
- Tek yönetici penceresi kullanın. İkinci bir yönetici penceresi açılması mevcut maçı sıfırlar.
- Maç kaydını saklamak için kapanmadan önce **Maç kaydını indir** düğmesini kullanın. İndirilen JSON dosyaları sonraki açılışta silinmez. JSON içe aktarma bulunmaz.

## Kontroller

| Kontrol | İşlev |
| --- | --- |
| Skor düğmeleri | İlgili takıma belirtilen puanı ekler. |
| Son sayıyı iptal et | En son puan getiren girişi iptal eder. Aradaki saat, kart ve ayar işlemlerini geri almaz. |
| Son işlemi geri al | En son işlemin öncesindeki duruma döner; maç saatini o ana geri alır ve durdurur. |
| Saati başlat / durdur | Saati kontrol eder. Metin alanında veya düğmede odak yokken **Boşluk** tuşu da kullanılabilir. |
| Saati düzenle | `DD:SS` biçiminde manuel saat düzeltmesi yapar. |
| Devre arası / 2. devreye geç / Uzatmaya geç | Maç aşamasını değiştirir; saat manuel başlatılır. |
| Sarı / Kırmızı | Girilen oyuncu numarası için kart ekler. |
| Kartı kaldır | Kart kaydını operatörün istediği anda kaldırır. |
| Yeni maç | Skor, saat, kartlar ve maç akışını temizler; takım ve organizasyon ayarlarını korur. |

Try ve conversion ayrı skor girişleridir; ayrı ayrı iptal edilir. Saat 40 ve 80 dakikada otomatik durmaz. İkinci devrede birikimli süre kullanılır; gerekirse başlangıcı manuel olarak `40:00` yapın.

## Son güncellemeler — 30 Eylül 2026

- Her yeni açılışta eski maç verilerinin sıfırlanması eklendi.
- Yönetici ve seyirci ekranlarına skor animasyonu eklendi.
- Saat ve kartları etkilemeden en son sayıyı iptal etme eklendi.
- Try / conversion dahil skor düğmelerindeki işlem sırası ve devre kısıtlamaları kaldırıldı.
- Sarı kartın 10 dakikalık sayacı kaldırıldı; kartlar tamamen manuel yönetiliyor.
- Yalnızca kayıt ekleyen **Conversion kaçtı / vazgeç** düğmeleri kaldırıldı.
- Seyirci yazıları büyütüldü; tam ekran kontrolü F11 ile yapılıyor.
- Yerel ve çevrimdışı çalışma korunuyor; ağ sunucusu kullanılmıyor.

## Kaynak yapısı

```text
Rugby Scoreboard/
├── .gitattributes
├── .gitignore
├── README.md
├── index.html
├── style.css
├── app.js
├── Baslat.cmd
├── Derle.cmd
└── desktop/
    └── Launcher.cs
```

| Dosya | Açıklama |
| --- | --- |
| `index.html` | Yönetici ve seyirci ekranlarının HTML yapısı. |
| `style.css` | Arayüz, LED görünümü ve skor animasyonları. |
| `app.js` | Skor, saat, kartlar, iptal işlemleri ve pencere eşitleme. |
| `desktop/Launcher.cs` | Dosyaları EXE içinde taşıyan ve tarayıcıyı açan Windows başlatıcısı. |
| `Derle.cmd` | EXE oluşturma komutu. |
| `Baslat.cmd` | Derlenen EXE'yi başlatır. |

## EXE derleme

Windows'ta .NET Framework C# derleyicisi gereklidir. `Derle.cmd` önce `Framework64`, ardından `Framework` klasöründeki `v4.0.30319\csc.exe` dosyasını arar.

```bat
Derle.cmd
```

Başarılı derleme, proje klasöründe `RugbyScoreboard.exe` üretir. HTML, CSS veya JavaScript değişikliklerinin EXE'ye yansıması için yeniden derleyin. Node.js, npm veya Python gerekmez.

## GitHub'a yüklenecek dosyalar

**Depoya yükleyin:** yukarıdaki kaynak ağacındaki dokuz dosya. `desktop/Launcher.cs` dosyasının klasör yapısını koruyun. `.gitignore` ve `.gitattributes` dosyalarını da dahil edin.

**GitHub Releases bölümüne ekleyin:** kullanıcıların doğrudan çalıştırabilmesi için `RugbyScoreboard.exe`. EXE bir derleme çıktısı olduğundan kaynak deposuna dahil edilmez.

**Yüklemeyin:** `.archive/` eski sürüm yedeği, test klasörleri, geçici dosyalar ve indirilen maç kayıtları. `.gitignore` bu dosyaları Git üzerinden yapılan eklemelerden dışlar; web arayüzüyle elle yüklerken de seçmeyin.

## Doğrulama kapsamı

Skor girişi, son sayı iptali, manuel kart kaldırma, açılışta sıfırlama ve seyirciye skor efekti aktarımı kod düzeyinde kontrol edildi. Derlenen EXE'nin gömülü HTML, CSS ve JavaScript dosyalarının güncel kaynaklarla eşleştiği doğrulandı. Fiziksel LED ekran üzerinde uçtan uca test yapılmadı.
