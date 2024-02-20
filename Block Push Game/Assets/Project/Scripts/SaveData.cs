using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public bool[] levelsUnlocked = new bool[40];
    public bool[] secretLevelsCompleted = new bool[4];
    public bool[] secretLevelsUnlocked = new bool[4];

    public SaveData(SaveManager saveManager)
    {
        levelsUnlocked = saveManager.levelsUnlocked;
        secretLevelsCompleted = saveManager.secretLevelsCompleted;
        secretLevelsUnlocked = saveManager.secretLevelsUnlocked;
    }
}
