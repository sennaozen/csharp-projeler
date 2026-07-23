using System;

namespace ArenaSavasSistemi
{
    public enum BattleAction
    {
        NormalAttack,
        PowerAttack,
        Defend,
        Heal,
        ShowStatus
    }

    public class GameMenu
    {
        public void ShowBattleMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=== Savaş Menüsü ===");
            Console.WriteLine("1) Normal Saldırı");
            Console.WriteLine("2) Güçlü Saldırı");
            Console.WriteLine("3) Savunma Yap");
            Console.WriteLine("4) Can Yenile");
            Console.WriteLine("5) Durum Göster");
            Console.Write("Seçiminiz: ");
        }

        public BattleAction GetPlayerAction()
        {
            while (true)
            {
                ShowBattleMenu();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        return BattleAction.NormalAttack;
                    case "2":
                        return BattleAction.PowerAttack;
                    case "3":
                        return BattleAction.Defend;
                    case "4":
                        return BattleAction.Heal;
                    case "5":
                        return BattleAction.ShowStatus;
                    default:
                        Console.WriteLine("Geçersiz seçim! Lütfen 1-5 arasında bir değer girin.");
                        break;
                }
            }
        }
    }
}
