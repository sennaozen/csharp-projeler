using System;

namespace RPGMagazaEnvanterSistemi
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("=== RPG Mağaza ve Envanter Sistemi ===");
            Console.Write("Karakter adınızı girin: ");
            string playerName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(playerName))
            {
                playerName = "Kahraman";
            }

            Player player = new Player(playerName);
            Shop shop = new Shop();
            ShopMenu shopMenu = new ShopMenu();

            RunShop(player, shop, shopMenu);

            BattleTester battleTester = new BattleTester(player);
            battleTester.RunTest();

            Console.WriteLine();
            Console.WriteLine("Programdan çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }

        // Kullanıcı mağazadan çıkmadan önce istediği kadar işlem yapabilir.
        private static void RunShop(Player player, Shop shop, ShopMenu shopMenu)
        {
            bool shopping = true;

            while (shopping)
            {
                ShopAction action = shopMenu.GetMainAction();

                switch (action)
                {
                    case ShopAction.BuyItem:
                        Item selected = shopMenu.GetItemChoice(shop);
                        if (selected != null)
                        {
                            shop.TryPurchase(player, selected);
                        }
                        break;

                    case ShopAction.ShowStatus:
                        player.ShowStatus();
                        break;

                    case ShopAction.ShowInventory:
                        player.Inventory.ShowInventory();
                        break;

                    case ShopAction.Exit:
                        shopping = false;
                        Console.WriteLine("Mağazadan çıkılıyor...");
                        break;
                }
            }
        }
    }
}
