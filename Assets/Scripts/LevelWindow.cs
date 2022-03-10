using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelWindow : View
{
    [SerializeField] private TextMeshProUGUI _currentLevelText;
    [SerializeField] private TextMeshProUGUI _totalExperience;
    [SerializeField] private TextMeshProUGUI _levelExperience;
    [SerializeField] private TextMeshProUGUI _reachNextLevelExperience;

    [SerializeField] private ProgressBar _levelProgressBar;
    [SerializeField] private Button _lowXPButton;
    [SerializeField] private Button _middleXPButton;
    [SerializeField] private Button _highXPButton;
    private LevelSystem _levelSystem;

    public override void Initialize()
    {
        _lowXPButton.onClick.AddListener(() => _levelSystem?.AddExperience(5));
        _middleXPButton.onClick.AddListener(() => _levelSystem?.AddExperience(50));
        _highXPButton.onClick.AddListener(() => _levelSystem?.AddExperience(500));
        _levelProgressBar.maximum = _levelSystem.GetExpNeededToLevel();
    }
    
    private void SetExperienceBarSize()
    {
        _levelProgressBar.current = _levelSystem.LevelExperience;
        _levelProgressBar.maximum = _levelSystem.GetExpNeededToLevel();
        _levelProgressBar.GetCurrentFill();
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        // Set the LevelSystem object
        _levelSystem = levelSystem;

        // Update the starting values
        SetLevelNumber();
        SetExperienceBarSize();
        SetExperienceText();

        // Subscribe to the changed events
        levelSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged;
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }
    private void LevelSystem_OnLevelChanged(object sender, EventArgs e)
    {
        // Level Changed, update text
        SetLevelNumber();
    }

    private void LevelSystem_OnExperienceChanged(object sender, EventArgs e)
    {
        // Experience changed, update bar size
        SetExperienceBarSize();
        SetExperienceText();
    }

    private void SetExperienceText()
    {
        _levelExperience.text = "" + _levelSystem.LevelExperience;
        _reachNextLevelExperience.text = "" + _levelSystem.GetExpNeededToLevel();
        _totalExperience.text = "" + _levelSystem.TotalExperience;
    }

    private void SetLevelNumber()
    {
        //Level starts at 0
        _currentLevelText.text = "" + (_levelSystem.Level + 1);
    }

}
