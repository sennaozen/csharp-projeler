using System;
class fibonachi
{
    static void Main(string[] args)
    {
        Console.WriteLine("Fibonacci Serisi");
        Console.WriteLine("Kaç terim istiyorsunuz? ");
        int terimSayisi = Convert.ToInt32(Console.ReadLine());
        int sayi1 = 0, sayi2 = 1, sayi3;
        Console.Write(sayi1 + " " + sayi2 + " ");
        for (int i = 2; i < terimSayisi; i++)
        {
            sayi3 = sayi1 + sayi2;
            Console.Write(sayi3 + " ");
            sayi1 = sayi2;
            sayi2 = sayi3;
        }
    }
}