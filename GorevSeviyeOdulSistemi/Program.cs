using System;

namespace GorevSeviyeOdulSistemi
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("=== Görev, Seviye ve Ödül Sistemi ===");
            Console.Write("Karakter adınızı girin: ");
            string playerName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(playerName))
            {
                playerName = "Kahraman";
            }

            Player player = new Player(playerName);
            LevelSystem levelSystem = new LevelSystem();
            QuestManager questManager = new QuestManager(levelSystem);
            QuestMenu questMenu = new QuestMenu();

            RunQuestLoop(player, questManager, questMenu);

            Console.WriteLine();
            Console.WriteLine("Programdan çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }

        private static void RunQuestLoop(Player player, QuestManager questManager, QuestMenu questMenu)
        {
            bool running = true;

            while (running)
            {
                QuestMenuAction action = questMenu.GetMainAction();

                switch (action)
                {
                    case QuestMenuAction.ShowQuests:
                        questManager.ShowQuests(player);
                        break;

                    case QuestMenuAction.CompleteQuest:
                        Quest selected = questMenu.GetQuestChoice(questManager, player);
                        if (selected != null)
                        {
                            questManager.TryCompleteQuest(player, selected);
                        }
                        break;

                    case QuestMenuAction.ShowStatus:
                        player.ShowStatus();
                        break;

                    case QuestMenuAction.Exit:
                        running = false;
                        Console.WriteLine("Görev sisteminden çıkılıyor...");
                        break;
                }
            }
        }
    }
}
