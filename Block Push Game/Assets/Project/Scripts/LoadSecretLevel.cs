using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSecretLevel : MonoBehaviour
{
    public int index;
    public GameObject[] lockImages = new GameObject[4];
    public GameObject numberText;
    private SaveManager saveManager;

    private Button button;

    private Animator screenTransition;

    private void Start()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        button = GetComponent<Button>();

        GameObject screen = GameObject.Find("ScreenTransition");
        if (screen != null)
            screenTransition = screen.GetComponentInChildren<Animator>();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadTheNextLevel());
    }

    private IEnumerator LoadTheNextLevel()
    {
        if (screenTransition != null)
        {
            screenTransition.SetTrigger("EndTransition");
        }
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(index);
    }

    private void Update()
    {
        
        if (IsUnlocked())
        {
            
            numberText.SetActive(true);

            foreach(GameObject lockObj in lockImages)
            {
                lockObj.SetActive(false);
            }

            button.interactable = true;
        }
        else
        {
            SetLockImages();
            numberText.SetActive(false);                     
            button.interactable = false;
        }
    }



    private bool IsUnlocked()
    {
        foreach(bool unlocked in saveManager.secretLevelsCompleted)
        {
            if (!unlocked)
                return false;
        }
        return true;
    }

    private void SetLockImages()
    {
        for (int i = 0; i < lockImages.Length; i++)
        {
            lockImages[i].SetActive(!saveManager.secretLevelsCompleted[i]);
        }
                
    }
}
