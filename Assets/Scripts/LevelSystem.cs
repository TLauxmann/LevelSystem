using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem
{
    public int Experience { get; private set; }
    public int LevelExperience { get; private set; }
    public int Level { get; private set; }
    public int ExperienceToNextLevel { get; private set; }

    public LevelSystem()
    {
        Level = 0;
        LevelExperience = 0;
        ExperienceToNextLevel = 100;
    }

    public void AddExperience(int amount)
    {
        LevelExperience += amount;
        if(LevelExperience >= ExperienceToNextLevel)
        {
            Level++;
            LevelExperience -= ExperienceToNextLevel;
        }
    }


}
