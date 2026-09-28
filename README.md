# Rugby Scoreboard — Yerel EXE

RugbyScoreboard.exe dosyasına çift tıklayın. Baslat.cmd de aynı uygulamayı başlatır.

EXE, arayüz dosyalarını içinde taşır ve uygulamayı varsayılan tarayıcıda açar. Sunucu, Wi-Fi veya internet bağlantısı gerekmez. Başka bir Windows bilgisayarına yalnız EXE dosyasını kopyalayabilirsiniz. Windows'ta .NET Framework 4.x ve güncel bir tarayıcı gerekir.

Çalışma dosyaları %LOCALAPPDATA%\RugbyScoreboard\LocalApp klasörüne çıkarılır. Her açılışta aynı konum kullanılır. Skor ve maç kaydı tarayıcının yerel depolamasında tutulur. Önceki index.html konumundaki tarayıcı kaydı bu yeni konuma otomatik taşınmaz.

Seyirci ekranı aynı bilgisayarda ayrı bir tarayıcı penceresinde açılır. İkinci monitöre taşıyıp F11 ile tam ekran yapabilirsiniz. Maç saati sekme kapalıyken de geçen süreyi sayar; kapatmadan önce durdurun.

Kaynak kod desktop/Launcher.cs, index.html, style.css ve app.js dosyalarındadır. Kaynaklarda değişiklik yaptıktan sonra Derle.cmd ile EXE'yi yeniden oluşturun.

Derleme doğrulamasında oluşturulan geçici dosyalar temizlendi. Önceki ağ sürümünün yedeği .archive/network-version klasöründe korunur; uygulama bu dosyaları kullanmaz.

Skor düğmeleri manuel yönetilir: try, conversion, penaltı, drop goal ve penalty try her maç aşamasında kullanılabilir. Conversion için önce try girme zorunluluğu yoktur; bekleyen conversion devre geçişini veya maç bitirmeyi engellemez. Yanlış girişler Son işlemi geri al düğmesiyle geri alınabilir.

Sarı kartta süre sayacı yoktur. Kartlar manuel eklenir ve Kartı kaldır düğmesine basılana kadar görünür. Kart kaldırma işlemi Son işlemi geri al ile geri alınabilir.
