namespace GorevSeviyeOdulSistemi
{
    public class Reward
    {
        public int XpAmount { get; private set; }
        public int GoldAmount { get; private set; }

        public Reward(int xpAmount, int goldAmount)
        {
            XpAmount = xpAmount;
            GoldAmount = goldAmount;
        }

                public void GrantGold(Player player)
        {
            player.AddGold(GoldAmount);
        }
    }
}
