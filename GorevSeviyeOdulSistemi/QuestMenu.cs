using System;

namespace GorevSeviyeOdulSistemi
{
    public enum QuestMenuAction
    {
        ShowQuests,
        CompleteQuest,
        ShowStatus,
        Exit
    }

    public class QuestMenu
    {
        public void ShowMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=== Görev Menüsü ===");
            Console.WriteLine("1) Görev Listesini Göster");
            Console.WriteLine("2) Görev Tamamla");
            Console.WriteLine("3) Karakter Durumunu Göster");
            Console.WriteLine("4) Çıkış");
            Console.Write("Seçiminiz: ");
        }

        
        public QuestMenuAction GetMainAction()
        {
            while (true)
            {
                ShowMainMenu();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        return QuestMenuAction.ShowQuests;
                    case "2":
                        return QuestMenuAction.CompleteQuest;
                    case "3":
                        return QuestMenuAction.ShowStatus;
                    case "4":
                        return QuestMenuAction.Exit;
                    default:
                        Console.WriteLine("Geçersiz seçim! Lütfen 1-4 arasında bir değer girin.");
                        break;
                }
            }
        }

        public Quest GetQuestChoice(QuestManager questManager, Player player)
        {
            questManager.ShowQuests(player);
            Console.Write("Tamamlamak istediğiniz görevin numarasını girin (iptal için 0): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int choice) || choice < 0 || choice > questManager.Quests.Count)
            {
                Console.WriteLine("Geçersiz numara.");
                return null;
            }

            if (choice == 0)
            {
                return null;
            }

            return questManager.Quests[choice - 1];
        }
    }
}
