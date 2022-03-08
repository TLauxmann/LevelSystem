using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private LevelWindow _levelWindow;

    private void Awake()
    {
        LevelSystem levelSystem = new LevelSystem();
        Debug.Log(levelSystem.Level);
        levelSystem.AddExperience(50);
        Debug.Log(levelSystem.Level);
        levelSystem.AddExperience(60);
        Debug.Log(levelSystem.Level);

        _levelWindow.SetLevelSystem(levelSystem);
    }
}
