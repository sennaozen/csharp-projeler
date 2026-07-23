using System;
class HesapMakinesi
{
    static void Main(string[]args)
    {
        Console.WriteLine("Hesap Makinesi");
        Console.WriteLine("1. Toplama");
        Console.WriteLine("2. Çıkarma");
        Console.WriteLine("3. Çarpma");
        Console.WriteLine("4. Bölme");
        Console.WriteLine("5. Çıkış");
        Console.WriteLine("Bir işlem seçiniz: ");
        int secim = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("1. Sayıyı Giriniz: ");
        double sayi1 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("2. Sayıyı Giriniz: ");
        double sayi2 = Convert.ToDouble(Console.ReadLine());
        switch (secim)
        {
            case 1:
                Console.WriteLine("Sonuç: " + (sayi1 + sayi2));
                break;
            case 2:
                Console.WriteLine("Sonuç: " + (sayi1 - sayi2));
                break;
            case 3:
                Console.WriteLine("Sonuç: " + (sayi1 * sayi2));
                break;
            case 4:
                if (sayi2 != 0)
                {
                    Console.WriteLine("Sonuç: " + (sayi1 / sayi2));
                }
                else
                {
                    Console.WriteLine("Sıfıra bölme hatası!");
                }
                break;
            case 5:
                Console.WriteLine("Çıkış yapılıyor...");
                break;
            default:
                Console.WriteLine("Geçersiz seçim!");
                break;
        }
    }
}