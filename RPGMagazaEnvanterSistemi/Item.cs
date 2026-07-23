namespace RPGMagazaEnvanterSistemi
{
    public enum ItemEffectType
    {
        AttackBoost,          // Saldırı gücünü kalıcı artırır (Demir Kılıç)
        DefenseBoost,         // Savunmayı kalıcı artırır (Çelik Zırh)
        InventoryHealPotion,  // Envantere eklenir, savaşta kullanılır (Can İksiri)
        InstantHeal,          // Satın alınınca anında can artırır (Büyük Can İksiri)
        MaxEnergyBoost        // Maksimum enerjiyi artırır (Enerji Taşı)
    }

    public class Item
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public ItemEffectType EffectType { get; private set; }
        public int EffectAmount { get; private set; }
        public bool IsOneTimePurchase { get; private set; }
        public int? MaxPurchaseCount { get; private set; }

        public int Stock { get; private set; }

        public Item(string name, int price, ItemEffectType effectType, int effectAmount,
            int stock, bool isOneTimePurchase = false, int? maxPurchaseCount = null)
        {
            Name = name;
            Price = price;
            EffectType = effectType;
            EffectAmount = effectAmount;
            Stock = stock;
            IsOneTimePurchase = isOneTimePurchase;
            MaxPurchaseCount = maxPurchaseCount;
        }

        public bool IsInStock => Stock > 0;

        public void ReduceStock()
        {
            if (Stock > 0)
            {
                Stock--;
            }
        }
    }
}
