using System;

public class LevelSystem
{

    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    private static readonly int[] experiencePerLevel = new[] { 100, 120, 140, 0 };

    public int TotalExperience { get; private set; }
    public int LevelExperience { get; private set; }
    public int Level { get; private set; }
    public int ExperienceToNextLevel { get; private set; }

    public LevelSystem()
    {
        Level = 1;
        TotalExperience = 0;
        LevelExperience = 0;
    }

    public void AddExperience(int amount)
    {
        if (!IsMaxLevel())
        {
            TotalExperience += amount;
            LevelExperience += amount;
            while (!IsMaxLevel() && LevelExperience >= GetExpNeededToLevel())
            {
                LevelExperience -= GetExpNeededToLevel();
                Level++;
                if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty);
            }
            if (IsMaxLevel())
            {
                TotalExperience -= LevelExperience;
                LevelExperience = 0;
            }
            if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);
        }
    }

    public int GetExpNeededToLevel()
    {
        return Level < experiencePerLevel.Length ? experiencePerLevel[Level - 1] : int.MaxValue;
    }

    public bool IsMaxLevel()
    {
        return Level == experiencePerLevel.Length;
    }


}
