# Ödev 2: RPG Mağaza ve Envanter Sistemi

## Açıklama
Bu ödevde oyuncunun bir RPG mağazasından ürün satın aldığı, ürünlerin karakter
özelliklerini (saldırı, savunma, can, enerji) ve envanteri etkilediği bir C#
Console uygulaması geliştirdim. Mağazadan çıkıldıktan sonra alınan ürünlerin
gerçekten işe yarayıp yaramadığını göstermek için kısa bir savaş testi de ekledim.

## Sınıf Yapısı ve Sorumluluklar
- Item: Ürün adını, fiyatını, etkisini, stok miktarını; tek seferlik veya limitli
  satın alma bilgisini taşıyor.
- Inventory: Oyuncunun sahip olduğu tüketilebilir ürünleri (örn. Can İksiri) ve
  adetlerini yönetiyor; ekleme, kullanma ve listeleme sorumluluğu burada.
- Player: Oyuncunun adını, altınını, canını, saldırı gücünü, savunmasını,
  enerjisini ve envanterini tutuyor. Tüm değerleri yalnızca kendi metotları
  (SpendGold, Heal, IncreaseAttackPower vb.) üzerinden değişecek şekilde
  tasarladım — dışarıdan kontrolsüz değiştirilemiyor.
- Shop: Ürün listesini ve stokları tutuyor; satın alma sırasında stok, altın
  yeterliliği, tek seferlik/limitli satın alma kurallarını kontrol ediyor ve
  geçerliyse ürünün etkisini oyuncuya uyguluyor.
- ShopMenu: Kullanıcıya mağaza seçeneklerini gösteriyor, geçersiz girişte
  kullanıcıyı atmadan tekrar soruyor.
- Enemy / BattleTester: Mağaza sonrası kısa test dövüşünü yürütüyor; oyuncunun
  satın aldığı kılıç, zırh ve iksirlerin savaş performansına gerçekten etki
  ettiğini gösteriyor.
- Program: Yalnızca oyuncuyu, mağazayı ve akışı başlatıyor; mağaza/kural
  mantığını kendi içinde barındırmıyor.

## Mağaza Kuralları
| Ürün | Fiyat | Etki | Kural |
|---|---|---|---|
| Demir Kılıç | 150 altın | Saldırı gücü +8 | Bir kez alınabilir |
| Çelik Zırh | 180 altın | Savunma +6 | Bir kez alınabilir |
| Can İksiri | 50 altın | Envantere eklenir (savaşta +25 can) | Birden fazla alınabilir |
| Büyük Can İksiri | 100 altın | Anında +40 can (üst sınırı aşmaz) | Stokla sınırlı |
| Enerji Taşı | 120 altın | Maksimum enerji +15 | En fazla 2 kez alınabilir |

- Oyuncunun başlangıç altını: 500.
- Altın yetersizse veya stok tükenmişse satın alma gerçekleşmiyor.
- Tek seferlik ürünleri ve satın alma limiti olan ürünleri oyuncu bazında takip
  ediyorum.
- Can artıran ürünler oyuncunun maksimum can sınırını aşamıyor.
- Kullanıcı mağazadan çıkmadan önce istediği kadar işlem yapabiliyor.


