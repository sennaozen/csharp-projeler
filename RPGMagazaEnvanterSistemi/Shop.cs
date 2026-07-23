using System;
using System.Collections.Generic;
using System.Linq;

namespace RPGMagazaEnvanterSistemi
{
    public class Shop
    {
        private readonly List<Item> items;

        public Shop()
        {
            items = new List<Item>
            {
                new Item("Demir Kılıç", price: 150, effectType: ItemEffectType.AttackBoost,
                    effectAmount: 8, stock: 1, isOneTimePurchase: true),

                new Item("Çelik Zırh", price: 180, effectType: ItemEffectType.DefenseBoost,
                    effectAmount: 6, stock: 1, isOneTimePurchase: true),

                new Item("Can İksiri", price: 50, effectType: ItemEffectType.InventoryHealPotion,
                    effectAmount: 25, stock: 10),

                new Item("Büyük Can İksiri", price: 100, effectType: ItemEffectType.InstantHeal,
                    effectAmount: 40, stock: 5),

                new Item("Enerji Taşı", price: 120, effectType: ItemEffectType.MaxEnergyBoost,
                    effectAmount: 15, stock: 5, maxPurchaseCount: 2)
            };
        }

        public IReadOnlyList<Item> Items => items;

        public Item FindItem(string name)
        {
            return items.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void ShowItems()
        {
            Console.WriteLine("=== Mağaza ===");
            for (int i = 0; i < items.Count; i++)
            {
                Item item = items[i];
                string stockText = item.IsInStock ? item.Stock.ToString() : "Tükendi";
                Console.WriteLine($"{i + 1}) {item.Name} - {item.Price} altın (Stok: {stockText})");
            }
            Console.WriteLine("----------------------");
        }

        // Altın, stok ve tekrar satın alma kurallarını kontrol edip satın almayı gerçekleştirir.
        public bool TryPurchase(Player player, Item item)
        {
            if (item == null)
            {
                Console.WriteLine("Böyle bir ürün yok.");
                return false;
            }

            if (!item.IsInStock)
            {
                Console.WriteLine($"{item.Name} stokta yok.");
                return false;
            }

            if (item.IsOneTimePurchase && player.GetPurchaseCount(item.Name) >= 1)
            {
                Console.WriteLine($"{item.Name} zaten satın alındı, tekrar alınamaz.");
                return false;
            }

            if (item.MaxPurchaseCount.HasValue && player.GetPurchaseCount(item.Name) >= item.MaxPurchaseCount.Value)
            {
                Console.WriteLine($"{item.Name} için satın alma sınırına ulaşıldı (en fazla {item.MaxPurchaseCount.Value} adet).");
                return false;
            }

            if (!player.SpendGold(item.Price))
            {
                Console.WriteLine($"Yeterli altının yok. {item.Name} için {item.Price} altın gerekiyor. Mevcut altın: {player.Gold}");
                return false;
            }

            ApplyItemEffect(player, item);
            item.ReduceStock();
            player.RegisterPurchase(item.Name);

            Console.WriteLine($"{item.Name} satın alındı! Kalan altın: {player.Gold}");
            return true;
        }

        private void ApplyItemEffect(Player player, Item item)
        {
            switch (item.EffectType)
            {
                case ItemEffectType.AttackBoost:
                    player.IncreaseAttackPower(item.EffectAmount);
                    break;
                case ItemEffectType.DefenseBoost:
                    player.IncreaseDefense(item.EffectAmount);
                    break;
                case ItemEffectType.InventoryHealPotion:
                    player.Inventory.AddItem(item.Name);
                    Console.WriteLine($"{item.Name} envantere eklendi.");
                    break;
                case ItemEffectType.InstantHeal:
                    player.Heal(item.EffectAmount);
                    break;
                case ItemEffectType.MaxEnergyBoost:
                    player.IncreaseMaxEnergy(item.EffectAmount);
                    break;
            }
        }
    }
}
