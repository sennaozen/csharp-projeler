namespace GorevSeviyeOdulSistemi
{
    public class Quest
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int RequiredLevel { get; private set; }
        public Reward Reward { get; private set; }

        public int? CompletionLimit { get; private set; }
        public int CompletionCount { get; private set; }

        public Quest(string name, string description, int requiredLevel,
            int xpReward, int goldReward, int? completionLimit = null)
        {
            Name = name;
            Description = description;
            RequiredLevel = requiredLevel;
            Reward = new Reward(xpReward, goldReward);
            CompletionLimit = completionLimit;
            CompletionCount = 0;
        }

        public bool IsUnlimited => !CompletionLimit.HasValue;

        public bool HasReachedLimit => CompletionLimit.HasValue && CompletionCount >= CompletionLimit.Value;

        public bool IsLevelSufficientFor(int playerLevel) => playerLevel >= RequiredLevel;

        public void RegisterCompletion()
        {
            CompletionCount++;
        }

        public string GetLimitText()
        {
            return IsUnlimited ? "Sınırsız" : $"{CompletionCount}/{CompletionLimit.Value} kez tamamlandı";
        }
    }
}
