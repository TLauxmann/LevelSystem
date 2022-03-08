using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentLevelText;
    [SerializeField] private ProgressBar _levelProgressBar;
    private LevelSystem _levelSystem;

    //
    private void Start()
    {
        //_levelProgressBar.maximum = LevelSystem.GetExpToNextLvl;
    }
    private void SetExperienceBarSize(int experience)
    {
        _levelProgressBar.current = experience;
    }

    private void SetLevelNumber(int levelNumber)
    {
        //Level starts at 0
        _currentLevelText.text = "" + (levelNumber + 1);
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        _levelSystem = levelSystem;

        SetLevelNumber(levelSystem.Level);
        SetExperienceBarSize(levelSystem.LevelExperience);
    }

}
