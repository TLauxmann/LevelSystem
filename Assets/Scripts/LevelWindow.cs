using System;
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

        _levelProgressBar.SetMaximum(_levelSystem.GetExpNeededToLevel());
    }
    

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        _levelSystem = levelSystem;

        SetLevelNumber();
        SetExperienceBarSize();
        SetExperienceText();

        levelSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged;
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }

    private void LevelSystem_OnExperienceChanged(object sender, EventArgs e)
    {
        SetExperienceBarSize();
        SetExperienceText();
    }

    private void LevelSystem_OnLevelChanged(object sender, EventArgs e)
    {
        SetLevelNumber();
    }

    private void SetExperienceBarSize()
    {
        _levelProgressBar.SetCurrent(_levelSystem.LevelExperience);
        _levelProgressBar.SetMaximum(_levelSystem.GetExpNeededToLevel());
    }

    private void SetExperienceText()
    {
        _levelExperience.text = "" + _levelSystem.LevelExperience;
        _reachNextLevelExperience.text = "" + _levelSystem.GetExpNeededToLevel();
        _totalExperience.text = "" + _levelSystem.TotalExperience;
    }

    private void SetLevelNumber()
    {
        _currentLevelText.text = "" + _levelSystem.Level;
    }



}
