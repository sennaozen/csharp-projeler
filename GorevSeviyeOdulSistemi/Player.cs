using System;

namespace GorevSeviyeOdulSistemi
{
    public class Player
    {
        private const int ActiveAdventurerThreshold = 5;
        private const int MasterAdventurerThreshold = 10;

        private const string DefaultTitle = "Çırak Maceracı";
        private const string ActiveAdventurerTitle = "Aktif Maceracı";
        private const string MasterAdventurerTitle = "Usta Maceracı";

        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Xp { get; private set; }
        public int Gold { get; private set; }
        public string Title { get; private set; }
        public int CompletedQuestCount { get; private set; }

        public Player(string name)
        {
            Name = name;
            Level = 1;
            Xp = 0;
            Gold = 0;
            Title = DefaultTitle;
            CompletedQuestCount = 0;
        }

        public void AddGold(int amount)
        {
            Gold += amount;
        }

        public void AddExperience(int amount)
        {
            Xp += amount;
        }

        public void SetLevel(int newLevel)
        {
            Level = newLevel;
        }

        public void RegisterQuestCompletion()
        {
            CompletedQuestCount++;
            UpdateTitle();
        }

        private void UpdateTitle()
        {
            string newTitle = Title;

            if (CompletedQuestCount >= MasterAdventurerThreshold)
            {
                newTitle = MasterAdventurerTitle;
            }
            else if (CompletedQuestCount >= ActiveAdventurerThreshold)
            {
                newTitle = ActiveAdventurerTitle;
            }

            if (newTitle != Title)
            {
                Title = newTitle;
                Console.WriteLine($"Yeni unvan kazandın: {Title}!");
            }
        }

        public void ShowStatus()
        {
            Console.WriteLine($"--- {Name} Durumu ---");
            Console.WriteLine($"Seviye: {Level}");
            Console.WriteLine($"XP: {Xp}");
            Console.WriteLine($"Altın: {Gold}");
            Console.WriteLine($"Unvan: {Title}");
            Console.WriteLine($"Tamamlanan Görev Sayısı: {CompletedQuestCount}");
            Console.WriteLine("----------------------");
        }
    }
}
