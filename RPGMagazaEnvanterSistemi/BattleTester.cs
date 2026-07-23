using System;

namespace RPGMagazaEnvanterSistemi
{
    public enum BattleTestAction
    {
        Attack,
        Defend,
        UsePotion,
        ShowStatus,
        Leave
    }

    public class BattleTester
    {
        private readonly Player player;
        private readonly Enemy enemy;
        private bool isDefending;

        private const string HealPotionName = "Can İksiri";
        private const int PotionHealAmount = 25;

        public BattleTester(Player player)
        {
            this.player = player;
            enemy = new Enemy("Mağaza Sonrası Test Canavarı", maxHealth: 80, attackPower: 18);
        }

        public void RunTest()
        {
            Console.WriteLine();
            Console.WriteLine("=== Kısa Savaş Testi ===");
            Console.WriteLine("Mağazadan aldığın ürünlerin gerçekten işe yarayıp yaramadığını görelim.");
            Console.WriteLine($"Karşında {enemy.Name} belirdi!");

            while (player.IsAlive() && enemy.IsAlive())
            {
                BattleTestAction action = GetAction();

                if (action == BattleTestAction.Leave)
                {
                    Console.WriteLine("Test dövüşünden çıkıldı.");
                    return;
                }

                bool enemyShouldAttack = ExecuteAction(action);

                if (enemyShouldAttack && enemy.IsAlive())
                {
                    EnemyAttack();
                }
            }

            AnnounceResult();
        }

        private BattleTestAction GetAction()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1) Saldır  2) Savun  3) Can İksiri Kullan  4) Durum Göster  5) Testten Çık");
                Console.Write("Seçiminiz: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        return BattleTestAction.Attack;
                    case "2":
                        return BattleTestAction.Defend;
                    case "3":
                        return BattleTestAction.UsePotion;
                    case "4":
                        return BattleTestAction.ShowStatus;
                    case "5":
                        return BattleTestAction.Leave;
                    default:
                        Console.WriteLine("Geçersiz seçim! Lütfen 1-5 arasında bir değer girin.");
                        break;
                }
            }
        }

        // Seçilen aksiyonu uygular. Düşmanın karşı saldırması gerekip gerekmediğini döndürür.
        private bool ExecuteAction(BattleTestAction action)
        {
            switch (action)
            {
                case BattleTestAction.Attack:
                    Console.WriteLine($"{player.Name} saldırdı! (Saldırı Gücü: {player.AttackPower})");
                    enemy.TakeDamage(player.AttackPower);
                    return true;

                case BattleTestAction.Defend:
                    isDefending = true;
                    Console.WriteLine($"{player.Name} savunmaya geçti. (Savunma: {player.Defense})");
                    return true;

                case BattleTestAction.UsePotion:
                    if (player.Inventory.UseItem(HealPotionName))
                    {
                        Console.WriteLine($"{HealPotionName} kullanıldı.");
                        player.Heal(PotionHealAmount);
                    }
                    else
                    {
                        Console.WriteLine($"Envanterde {HealPotionName} yok.");
                    }
                    return true;

                case BattleTestAction.ShowStatus:
                    player.ShowStatus();
                    enemy.ShowStatus();
                    return false;

                default:
                    return false;
            }
        }

        private void EnemyAttack()
        {
            Console.WriteLine($"{enemy.Name} saldırıya geçti!");

            if (isDefending)
            {
                Console.WriteLine($"{player.Name} savunmadaydı, hasar azaltılıyor.");
                // Savunma sırasında düşman saldırı gücü yarıya iner, ardından Defense değeri de düşürür.
                player.TakeDamage(enemy.AttackPower / 2);
                isDefending = false;
            }
            else
            {
                player.TakeDamage(enemy.AttackPower);
            }
        }

        private void AnnounceResult()
        {
            Console.WriteLine();
            Console.WriteLine("=== Test Sonucu ===");

            if (player.IsAlive() && !enemy.IsAlive())
            {
                Console.WriteLine($"{player.Name} test dövüşünü kazandı! Mağazadan alınan ürünler işini gördü.");
            }
            else if (!player.IsAlive())
            {
                Console.WriteLine($"{player.Name} test dövüşünü kaybetti. Belki bir dahaki sefere daha iyi ekipman gerekir.");
            }
        }
    }
}
