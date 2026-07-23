using System;
using System.Collections.Generic;

namespace GorevSeviyeOdulSistemi
{
    public class QuestManager
    {
        private readonly List<Quest> quests;
        private readonly LevelSystem levelSystem;

        public QuestManager(LevelSystem levelSystem)
        {
            this.levelSystem = levelSystem;

            quests = new List<Quest>
            {
                new Quest("Slime Temizliği", "Köy çevresindeki slime'ları temizle.",
                    requiredLevel: 1, xpReward: 40, goldReward: 30, completionLimit: null),

                new Quest("Kayıp Eşyayı Bul", "Köylünün kaybettiği eşyayı bul ve geri getir.",
                    requiredLevel: 1, xpReward: 35, goldReward: 25, completionLimit: null),

                new Quest("Köyü Koru", "Köyü gece baskınına karşı savun.",
                    requiredLevel: 2, xpReward: 80, goldReward: 60, completionLimit: 3),

                new Quest("Zindan Keşfi", "Yakındaki zindanı keşfet.",
                    requiredLevel: 3, xpReward: 120, goldReward: 90, completionLimit: 2),

                new Quest("Boss Savaşı", "Bölgenin boss'unu yen.",
                    requiredLevel: 4, xpReward: 200, goldReward: 150, completionLimit: 1)
            };
        }

        public IReadOnlyList<Quest> Quests => quests;

        public void ShowQuests(Player player)
        {
            Console.WriteLine("=== Görev Listesi ===");
            for (int i = 0; i < quests.Count; i++)
            {
                Quest quest = quests[i];
                string status;

                if (quest.HasReachedLimit)
                {
                    status = "Limit Doldu";
                }
                else if (!quest.IsLevelSufficientFor(player.Level))
                {
                    status = $"Seviye {quest.RequiredLevel} gerekli";
                }
                else
                {
                    status = "Uygun";
                }

                Console.WriteLine($"{i + 1}) {quest.Name} - {quest.Description}");
                Console.WriteLine($"   Seviye Şartı: {quest.RequiredLevel} | XP: {quest.Reward.XpAmount} | Altın: {quest.Reward.GoldAmount} | Limit: {quest.GetLimitText()} | Durum: {status}");
            }
            Console.WriteLine("----------------------");
        }

        // Seviye ve limit kontrolünü yapar; uygunsa görevi tamamlayıp ödülü verir.
        public bool TryCompleteQuest(Player player, Quest quest)
        {
            if (quest == null)
            {
                Console.WriteLine("Böyle bir görev yok.");
                return false;
            }

            if (!quest.IsLevelSufficientFor(player.Level))
            {
                Console.WriteLine($"{quest.Name} için seviye {quest.RequiredLevel} gerekiyor. Mevcut seviyen: {player.Level}.");
                return false;
            }

            if (quest.HasReachedLimit)
            {
                Console.WriteLine($"{quest.Name} tamamlanma limitine ulaştı, tekrar yapılamaz.");
                return false;
            }

            quest.RegisterCompletion();
            quest.Reward.GrantGold(player);
            levelSystem.AddExperience(player, quest.Reward.XpAmount);
            player.RegisterQuestCompletion();

            Console.WriteLine($"{quest.Name} tamamlandı! Kazanılan: {quest.Reward.XpAmount} XP, {quest.Reward.GoldAmount} altın.");
            return true;
        }
    }
}
