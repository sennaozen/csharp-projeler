# Ödev 3: Görev, Seviye ve Ödül Sistemi

## Açıklama
Bu ödevde oyuncunun görevleri tamamlayarak XP ve altın kazandığı, belirli XP
eşiklerinde seviye atladığı ve tamamladığı görev sayısına göre unvan kazandığı uygulama geliştiridm.


Reward: Bir görevin XP ve altın ödülünü temsil ediyor; altın ödülünü
  oyuncuya vermekten sorumlu.


Quest: Görev adını, açıklamasını, seviye şartını, ödülünü (Reward) ve
  tamamlanma limitini/sayacını taşıyor. Limit kontrolünü ve durum metnini
  (GetLimitText) burada yönettim — dağınık değişkenler yerine tek bir yerde
  topladım.


Player: Oyuncunun adını, seviyesini, XP'sini, altınını, unvanını ve
  tamamladığı görev sayısını tutuyor. Seviyeyi yalnızca SetLevel üzerinden
  (LevelSystem tarafından) değiştirilebilecek şekilde tasarladım; unvan ise
  tamamlanan görev sayısına göre kendi içinde güncelleniyor.

LevelSystem: XP eşiklerine göre seviye atlama kontrolünü Player'dan
  bağımsız olarak yürütüyor. Tek seferde birden fazla eşik aşılsa bile (örn.
  büyük bir XP ödülüyle) doğrudan en yüksek uygun seviyeye atlıyor, ara
  seviyelerde takılmıyor.


QuestManager: Görev listesini tutuyor, seviye ve limit kurallarını
  kontrol ediyor, uygunsa ödülü veriyor ve LevelSystem'i tetikliyor — görev
  tamamlama akışının merkezi burası.


QuestMenu: Kullanıcıya görev menüsünü gösteriyor; geçersiz girişte
  kullanıcıyı programdan atmadan tekrar soruyor.



Program: Yalnızca oyuncuyu ve sistemleri başlatıyor, döngüyü yönetiyor;
  görev kurallarını kendi içinde barındırmıyor.

## Görev Listesi
Görev               Seviye Şartı    XP    Altın    Limit 
Slime Temizliği      1              40    30.    Sınırsız 
Kayıp Eşyayı Bul     1              35    25.    Sınırsız 
Köyü Koru            2              80    60     3 
Zindan Keşfi         3              120   90     2  
Boss Savaşı          4              200   150    1 

## Seviye Atlama Eşikleri

 0 XP  Seviye 1 
 100 XP  Seviye 2 
 250 XP Seviye 3 
 450 XP  Seviye 4 
 700 XP  Seviye 5 

## Unvan Kuralları
- 5 görev tamamlandığında: Aktif Maceracı 
- 10 görev tamamlandığında: Usta Maceracı

## İş Kuralları
- Görev seçildiğinde önce seviye şartını, sonra tamamlanma limitini kontrol
  ediyorum.
- Görev tamamlandığında XP ve altın veriliyor; XP eklendikten hemen sonra
  seviye atlama kontrolü otomatik yapılıyor.
- Seviye atlandığında ekrana başarı mesajı yazdırılıyor.

