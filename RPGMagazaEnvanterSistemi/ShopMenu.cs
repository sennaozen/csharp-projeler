using System;

namespace RPGMagazaEnvanterSistemi
{
    public enum ShopAction
    {
        BuyItem,
        ShowStatus,
        ShowInventory,
        Exit
    }

    public class ShopMenu
    {
        public void ShowMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=== Mağaza Menüsü ===");
            Console.WriteLine("1) Ürün Satın Al");
            Console.WriteLine("2) Karakter Durumunu Göster");
            Console.WriteLine("3) Envanteri Göster");
            Console.WriteLine("4) Mağazadan Çık");
            Console.Write("Seçiminiz: ");
        }

        // Hatalı giriş kullanıcıyı programdan atmaz, geçerli seçim yapılana kadar tekrar sorar.
        public ShopAction GetMainAction()
        {
            while (true)
            {
                ShowMainMenu();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        return ShopAction.BuyItem;
                    case "2":
                        return ShopAction.ShowStatus;
                    case "3":
                        return ShopAction.ShowInventory;
                    case "4":
                        return ShopAction.Exit;
                    default:
                        Console.WriteLine("Geçersiz seçim! Lütfen 1-4 arasında bir değer girin.");
                        break;
                }
            }
        }

        // Kullanıcının satın almak istediği ürünü seçmesini sağlar. İptal için 0 döner (null).
        public Item GetItemChoice(Shop shop)
        {
            shop.ShowItems();
            Console.Write("Satın almak istediğiniz ürünün numarasını girin (iptal için 0): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int choice) || choice < 0 || choice > shop.Items.Count)
            {
                Console.WriteLine("Geçersiz numara.");
                return null;
            }

            if (choice == 0)
            {
                return null;
            }

            return shop.Items[choice - 1];
        }
    }
}
