using System;

namespace ArenaSavasSistemi
{
    public class Player
    {
        public string Name { get; private set; }

        private int health;
        private int energy;
        private int gold;

        public int MaxHealth { get; private set; }
        public int MaxEnergy { get; private set; }

        public bool IsDefending { get; private set; }

        private const int NormalAttackDamage = 12;
        private const int PowerAttackDamage = 22;
        private const int PowerAttackEnergyCost = 20;
        private const int HealAmount = 20;
        private const int HealEnergyCost = 15;
        private const int EnergyRegenPerTurn = 5;

        public Player(string name)
        {
            Name = name;
            MaxHealth = 100;
            MaxEnergy = 60;
            health = MaxHealth;
            energy = MaxEnergy;
            gold = 0;
            IsDefending = false;
        }

        public int Health => health;
        public int Energy => energy;
        public int Gold => gold;

        public bool IsAlive()
        {
            return health > 0;
        }

        // normalattackta enerji harcanmaz
        public void NormalAttack(Enemy enemy)
        {
            Console.WriteLine($"{Name} normal saldırı yaptı!");
            enemy.TakeDamage(NormalAttackDamage);
        }

        // powerattack enerji harcar 
        public void PowerAttack(Enemy enemy)
        {
            if (energy < PowerAttackEnergyCost)
            {
                Console.WriteLine($"{Name}'in güçlü saldırı için yeterli enerjisi yok! Bunun yerine normal saldırı yapıyor.");
                NormalAttack(enemy);
                return;
            }

            energy -= PowerAttackEnergyCost;
            Console.WriteLine($"{Name} güçlü bir saldırı gerçekleştirdi!");
            enemy.TakeDamage(PowerAttackDamage);
        }

        
        public void Defend()
        {
            IsDefending = true;
            Console.WriteLine($"{Name} savunma pozisyonuna geçti.");
        }

        // Can yenileme kısmı maxhealthden yüksek olamaz
        public void Heal()
        {
            if (energy < HealEnergyCost)
            {
                Console.WriteLine($"{Name}'in can yenilemek için yeterli enerjisi yok!");
                return;
            }

            energy -= HealEnergyCost;
            health = Math.Min(MaxHealth, health + HealAmount);
            Console.WriteLine($"{Name} kendini iyileştirdi. Can: {health}/{MaxHealth}");
        }

        public void ShowStatus()
        {
            Console.WriteLine($"--- {Name} Durumu ---");
            Console.WriteLine($"Can: {health}/{MaxHealth}");
            Console.WriteLine($"Enerji: {energy}/{MaxEnergy}");
            Console.WriteLine($"Altın: {gold}");
            Console.WriteLine("----------------------");
        }

        // Hasar alma defendingdeyse hasar azlt 
        public void TakeDamage(int amount)
        {
            int finalDamage = amount;

            if (IsDefending)
            {
                finalDamage = amount / 2;
                IsDefending = false;
                Console.WriteLine($"{Name} saldırıyı kısmen savuşturdu!");
            }

            health -= finalDamage;
            if (health < 0)
            {
                health = 0;
            }

            Console.WriteLine($"{Name} {finalDamage} hasar aldı. Kalan can: {health}/{MaxHealth}");
        }

        public void AddGold(int amount)
        {
            gold += amount;
        }

       
        public void RegenEnergy()
        {
            energy = Math.Min(MaxEnergy, energy + EnergyRegenPerTurn);
        }
    }
}
