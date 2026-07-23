using System;

namespace ArenaSavasSistemi
{
    public class Enemy
    {
        public string Name { get; private set; }
        public int MaxHealth { get; private set; }
        public int AttackPower { get; private set; }

        private int health;

        public Enemy(string name, int maxHealth, int attackPower)
        {
            Name = name;
            MaxHealth = maxHealth;
            health = maxHealth;
            AttackPower = attackPower;
        }

        public int Health => health;

        public bool IsAlive()
        {
            return health > 0;
        }

                public void Attack(Player player)
        {
            Console.WriteLine($"{Name} saldırıya geçti!");
            player.TakeDamage(AttackPower);
        }

        public void TakeDamage(int amount)
        {
            health -= amount;
            if (health < 0)
            {
                health = 0;
            }

            Console.WriteLine($"{Name} {amount} hasar aldı. Kalan can: {health}/{MaxHealth}");
        }

        public void ShowStatus()
        {
            Console.WriteLine($"--- {Name} Durumu ---");
            Console.WriteLine($"Can: {health}/{MaxHealth}");
            Console.WriteLine($"Saldırı Gücü: {AttackPower}");
            Console.WriteLine("----------------------");
        }
    }
}
