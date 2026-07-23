# Ödev 1: Arena Savaş Sistemi

## Açıklama
Bu ödevde oyuncu ile düşman arasında tur bazlı bir arena savaşı kurguladım. Savaş, oyuncunun
veya düşmanın canı sıfırlanana kadar devam ediyor. Amacım sadece hasar verip canı azaltmak
değil, savaş sistemini sınıflar ve sorumluluklar üzerinden doğru şekilde tasarlamaktı.

## Sınıf Yapısı ve Sorumluluklar
- **Player**: Oyuncunun adını, canını, enerjisini, altınını ve savunma durumunu tutuyor;
  normal saldırı, güçlü saldırı, savunma, can yenileme gibi davranışları kendi metotları
  üzerinden yönetiyor. Can/enerji/altın değerlerini dışarıdan doğrudan değiştirilemeyecek
  şekilde tasarladım (encapsulation), bu değerler yalnızca sınıfın kendi metotları
  aracılığıyla güncelleniyor.
- **Enemy**: Düşmanın adını, canını ve saldırı gücünü tutuyor; saldırı ve hasar alma
  davranışlarını kendi içinde yönetiyor.
- **BattleManager**: Savaşın tur akışını yönetiyor, hangi aksiyondan sonra düşmanın saldırması
  gerektiğine karar veriyor, kazanma/kaybetme durumunu kontrol ediyor ve altın ödülünü
  veriyor.
- **GameMenu**: Kullanıcıya savaş seçeneklerini sunuyor; geçersiz girişlerde kullanıcıyı
  programdan atmadan tekrar soruyor.
- **Program**: Yalnızca oyuncu adını alıyor, nesneleri oluşturuyor ve savaşı başlatıyor;
  savaş mantığını kendi içinde barındırmıyor.

## Oyun Kuralları
- Oyuncu başlangıç canı: 100, başlangıç enerjisi: 60.
- Düşman başlangıç canı: 90, saldırı gücü: 14 (Program.cs içinde tanımladım).
- Normal saldırı: enerji harcamıyor, 12 hasar veriyor.
- Güçlü saldırı: 20 enerji harcıyor, 22 hasar veriyor (yetersiz enerjide otomatik olarak
  normal saldırıya dönüyor).
- Savunma: yalnızca bir sonraki düşman saldırısında hasarı yarıya indiriyor.
- Can yenileme: 15 enerji harcıyor, 20 can iyileştiriyor, maksimum canı aşmıyor.
- Düşman, "Durum Göster" dışındaki her oyuncu aksiyonundan sonra saldırıyor.
- Enerji her tur sonunda 5 birim yenileniyor, maksimum sınırı aşmıyor.
- Savaş kazanılırsa oyuncuya 50 altın ödülü veriliyor.

