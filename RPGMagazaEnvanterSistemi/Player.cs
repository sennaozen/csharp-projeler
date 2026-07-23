using System;
using System.Collections.Generic;

namespace RPGMagazaEnvanterSistemi
{
    public class Player
    {
        public string Name { get; private set; }
        public int Gold { get; private set; }
        public int MaxHealth { get; private set; }
        public int AttackPower { get; private set; }
        public int Defense { get; private set; }
        public int MaxEnergy { get; private set; }
        public Inventory Inventory { get; private set; }

        private int health;
        private int energy;

        // Ürün adına göre kaç kez satın alındığını tutar (tek seferlik / limitli ürün kontrolü için).
        private readonly Dictionary<string, int> purchaseCounts = new Dictionary<string, int>();

        public Player(string name)
        {
            Name = name;
            Gold = 500;
            MaxHealth = 100;
            health = MaxHealth;
            AttackPower = 10;
            Defense = 5;
            MaxEnergy = 50;
            energy = MaxEnergy;
            Inventory = new Inventory();
        }

        public int Health => health;
        public int Energy => energy;

        public bool IsAlive()
        {
            return health > 0;
        }

        // Altın yetersizse harcama yapılmaz, false döner.
        public bool SpendGold(int amount)
        {
            if (amount > Gold)
            {
                return false;
            }

            Gold -= amount;
            return true;
        }

        public void AddGold(int amount)
        {
            Gold += amount;
        }

        public void IncreaseAttackPower(int amount)
        {
            AttackPower += amount;
            Console.WriteLine($"{Name}'in saldırı gücü {amount} arttı. Yeni saldırı gücü: {AttackPower}");
        }

        public void IncreaseDefense(int amount)
        {
            Defense += amount;
            Console.WriteLine($"{Name}'in savunması {amount} arttı. Yeni savunma: {Defense}");
        }

        // Can, maksimum can sınırını aşamaz.
        public void Heal(int amount)
        {
            int before = health;
            health = Math.Min(MaxHealth, health + amount);
            Console.WriteLine($"{Name} {health - before} can kazandı. Can: {health}/{MaxHealth}");
        }

        public void IncreaseMaxEnergy(int amount)
        {
            MaxEnergy += amount;
            energy = Math.Min(MaxEnergy, energy + amount);
            Console.WriteLine($"{Name}'in maksimum enerjisi {amount} arttı. Yeni maksimum enerji: {MaxEnergy}");
        }

        // Savunma değeri hasarı azaltır; hasar en az 1 olur.
        public void TakeDamage(int incomingAttackPower)
        {
            int finalDamage = Math.Max(1, incomingAttackPower - Defense);
            health -= finalDamage;
            if (health < 0)
            {
                health = 0;
            }

            Console.WriteLine($"{Name} {finalDamage} hasar aldı. Kalan can: {health}/{MaxHealth}");
        }

        public int GetPurchaseCount(string itemName)
        {
            return purchaseCounts.TryGetValue(itemName, out int count) ? count : 0;
        }

        public void RegisterPurchase(string itemName)
        {
            purchaseCounts[itemName] = GetPurchaseCount(itemName) + 1;
        }

        public void ShowStatus()
        {
            Console.WriteLine($"--- {Name} Durumu ---");
            Console.WriteLine($"Can: {health}/{MaxHealth}");
            Console.WriteLine($"Enerji: {energy}/{MaxEnergy}");
            Console.WriteLine($"Saldırı Gücü: {AttackPower}");
            Console.WriteLine($"Savunma: {Defense}");
            Console.WriteLine($"Altın: {Gold}");
            Console.WriteLine("----------------------");
        }
    }
}
