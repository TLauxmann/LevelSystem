using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private LevelWindow _levelWindow;

    private void Awake()
    {
        LevelSystem levelSystem = new LevelSystem();
        _levelWindow.SetLevelSystem(levelSystem);
        _levelWindow.Initialize();
    }
}
