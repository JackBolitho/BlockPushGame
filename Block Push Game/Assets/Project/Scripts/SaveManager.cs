using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public bool[] levelsUnlocked = new bool[40];
    public bool[] secretLevelsUnlocked = new bool[4];
    public bool[] secretLevelsCompleted = new bool[4];

    private List<LoadLevel> levelsToLoad = new List<LoadLevel>();

    private static SaveManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(instance);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //sets level 1 and the first world button
        levelsUnlocked[0] = true;
        levelsUnlocked[36] = true;

        GetAndSetUnlockedLevels(); 
    }

    public void GetAndSetUnlockedLevels()
    {
        if (SceneManager.GetActiveScene().name.Contains("LevelSelect"))
        {
            LoadSaveData();
            GetLevelsToLoad();
            SetLevelButtonsToUnlocks();
        }
    }

    private void GetLevelsToLoad()
    {
        levelsToLoad.Clear();
        foreach(Transform child in GameObject.Find("Canvas").transform)
        {
            LoadLevel loader = child.gameObject.GetComponent<LoadLevel>();
            if(loader != null && !loader.name.Contains("Exit"))
            {
                levelsToLoad.Add(loader);
            }
        }
    }

    private void SetLevelButtonsToUnlocks()
    {
        foreach(LoadLevel level in levelsToLoad)
        {
            level.unlocked = levelsUnlocked[level.index - 1];
        }
    }

    public void SaveGameData()
    {
        SaveSystem.SavePlayer(this);
    }

    private void LoadSaveData()
    {
        SaveData data = SaveSystem.LoadData();

        for(int i = 0; i < levelsUnlocked.Length; i++)
        {
            levelsUnlocked[i] = data.levelsUnlocked[i];
        }
    }
}
