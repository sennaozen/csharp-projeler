using System;
 
    class dizinot
    {
        static void Main(string[]args)
    {
        int[] array = new int[5];
        Console.WriteLine("5 adet not giriniz: ");
        for (int i = 0; i < 5; i++)
        {
            array[i] = Convert.ToInt32(Console.ReadLine()); 
        }
        foreach (int i in array)
        {
            Console.WriteLine(i);
        }
        ortalama(array);
        derstengecenler(array);

        
    }
    static void ortalama(int[] array)
    {
        foreach (int i in array)
        {
            int toplam = 0;
            toplam += i;
            double ortalama = toplam / 5.0;
            Console.WriteLine("Ortalama: " + ortalama);
        }

    }
    static void derstengecenler(int[] array)
    {
        foreach (int i in array)
        {
            if (i >= 50)
            {
                Console.WriteLine("Geçti: " + i);
            }
            else
            {
                Console.WriteLine("Kaldı: " + i);
            }
        }
    }
}
