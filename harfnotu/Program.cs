using System;
class Notdegerlendirme
{
    static void Main(string[] args)
    {
        int not1, not2, not3;
        Console.WriteLine("1. Notu Giriniz: ");
        not1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("2. Notu Giriniz: ");
        not2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("3. Notu Giriniz: ");
        not3 = Convert.ToInt32(Console.ReadLine());
        NotHesapla(not1, not2, not3);
        NotDegerlendir((not1 + not2 + not3) / 3.0);
        Console.WriteLine("Harf notunuz hesaplanmıştır.");

    }
    static void NotHesapla(int not1, int not2, int not3)
    {
        double ortalama = (not1 + not2 + not3) / 3.0;
        
    }
    static void NotDegerlendir(double ortalama)
    {
        if (ortalama >= 90)
        {
            Console.WriteLine("Notunuz: AA");
        }
        else if (ortalama >= 80)
        {
            Console.WriteLine("Notunuz: BA");
        }
        else if (ortalama >= 70)
        {
            Console.WriteLine("Notunuz: BB");
        }
        else if (ortalama >= 60)
        {
            Console.WriteLine("Notunuz: CB");
        }
        else if (ortalama >= 50)
        {
            Console.WriteLine("Notunuz: CC");
        }
        else
        {
            Console.WriteLine("Notunuz: FF");
        }
    }
}