using System;

namespace ArenaSavasSistemi
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("=== Arena Savaş Sistemi ===");
            Console.Write("Karakter adınızı girin: ");
            string playerName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(playerName))
            {
                playerName = "Kahraman";
            }

            Player player = new Player(playerName);
            Enemy enemy = new Enemy("Karanlık Savaşçı", maxHealth: 90, attackPower: 14);

            BattleManager battleManager = new BattleManager(player, enemy);
            battleManager.StartBattle();

            Console.WriteLine();
            Console.WriteLine("Programdan çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
