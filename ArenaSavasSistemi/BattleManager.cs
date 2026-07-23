using System;

namespace ArenaSavasSistemi
{
    public class BattleManager
    {
        private readonly Player player;
        private readonly Enemy enemy;
        private readonly GameMenu menu;

        private const int VictoryGoldReward = 50;

        public BattleManager(Player player, Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;
            this.menu = new GameMenu();
        }

        public void StartBattle()
        {
            Console.WriteLine();
            Console.WriteLine($"{player.Name}, arenaya girdin! Karşında {enemy.Name} var.");

            while (player.IsAlive() && enemy.IsAlive())
            {
                RunTurn();
            }

            AnnounceResult();
        }

        private void RunTurn()
        {
            BattleAction action = menu.GetPlayerAction();
            bool enemyShouldAttack = ExecutePlayerAction(action);

            // Durum gösterme dışında, oyuncunun aksiyonu sonrası düşman saldırır.
            if (enemyShouldAttack && enemy.IsAlive())
            {
                enemy.Attack(player);
            }

            if (!player.IsAlive() || !enemy.IsAlive())
            {
                return;
            }

            player.RegenEnergy();
        }

        // Seçilen aksiyonu uygular. Düşmanın karşı saldırması gerekip gerekmediğini döndürür.
        private bool ExecutePlayerAction(BattleAction action)
        {
            switch (action)
            {
                case BattleAction.NormalAttack:
                    player.NormalAttack(enemy);
                    return true;
                case BattleAction.PowerAttack:
                    player.PowerAttack(enemy);
                    return true;
                case BattleAction.Defend:
                    player.Defend();
                    return true;
                case BattleAction.Heal:
                    player.Heal();
                    return true;
                case BattleAction.ShowStatus:
                    player.ShowStatus();
                    enemy.ShowStatus();
                    return false;
                default:
                    return false;
            }
        }

        private void AnnounceResult()
        {
            Console.WriteLine();
            Console.WriteLine("=== Savaş Sonucu ===");

            if (player.IsAlive() && !enemy.IsAlive())
            {
                player.AddGold(VictoryGoldReward);
                Console.WriteLine($"{player.Name} savaşı kazandı! {VictoryGoldReward} altın kazanıldı.");
                Console.WriteLine($"Toplam altın: {player.Gold}");
            }
            else if (!player.IsAlive())
            {
                Console.WriteLine($"{player.Name} savaşı kaybetti. {enemy.Name} galip geldi.");
            }
        }
    }
}
