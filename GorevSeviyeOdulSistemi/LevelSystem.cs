using System;
using System.Collections.Generic;

namespace GorevSeviyeOdulSistemi
{
    public class LevelSystem
    {
                private readonly List<(int RequiredXp, int Level)> thresholds = new List<(int, int)>
        {
            (0, 1),
            (100, 2),
            (250, 3),
            (450, 4),
            (700, 5)
        };

                public void AddExperience(Player player, int amount)
        {
            player.AddExperience(amount);
            CheckForLevelUp(player);
        }

        private void CheckForLevelUp(Player player)
        {
            int highestEligibleLevel = player.Level;

            foreach (var threshold in thresholds)
            {
                if (player.Xp >= threshold.RequiredXp && threshold.Level > highestEligibleLevel)
                {
                    highestEligibleLevel = threshold.Level;
                }
            }

            if (highestEligibleLevel > player.Level)
            {
                int previousLevel = player.Level;
                player.SetLevel(highestEligibleLevel);

                Console.WriteLine();
                Console.WriteLine($"*** Tebrikler {player.Name}! Seviye {previousLevel} -> Seviye {highestEligibleLevel} atladın! ***");
            }
        }
    }
}
