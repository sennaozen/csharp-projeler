using System;
using System.Collections.Generic;
using System.Linq;

namespace RPGMagazaEnvanterSistemi
{
    public class Inventory
    {
        private readonly Dictionary<string, int> items = new Dictionary<string, int>();

        public void AddItem(string itemName, int quantity = 1)
        {
            if (items.ContainsKey(itemName))
            {
                items[itemName] += quantity;
            }
            else
            {
                items[itemName] = quantity;
            }
        }

        public bool HasItem(string itemName)
        {
            return items.ContainsKey(itemName) && items[itemName] > 0;
        }

        // Envanterden bir adet ürün kullanır. Ürün yoksa false döner.
        public bool UseItem(string itemName)
        {
            if (!HasItem(itemName))
            {
                return false;
            }

            items[itemName]--;
            return true;
        }

        public int GetQuantity(string itemName)
        {
            return items.TryGetValue(itemName, out int quantity) ? quantity : 0;
        }

        public void ShowInventory()
        {
            Console.WriteLine("--- Envanter ---");

            var ownedItems = items.Where(kv => kv.Value > 0).ToList();

            if (ownedItems.Count == 0)
            {
                Console.WriteLine("Envanter boş.");
            }
            else
            {
                foreach (var kv in ownedItems)
                {
                    Console.WriteLine($"{kv.Key} x{kv.Value}");
                }
            }

            Console.WriteLine("----------------");
        }
    }
}
