using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPlate : Plate
{
    private SaveManager saveManager;
    private Animator animator;

    public bool activated = true;
    public bool secret = false;

    private void Start()
    {
        GameObject manager = GameObject.Find("SaveManager");
        if(manager != null)
        {
            saveManager = manager.GetComponent<SaveManager>();
        }

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (ObjectWithSpecificNameIsOnPlate("Player") && activated)
        {
            if (secret)
            {
                saveManager.secretLevelsCompleted[SceneManager.GetActiveScene().buildIndex - 37] = true;
                saveManager.GetAndSetUnlockedLevels();
            }
            else
                StartCoroutine(LoadNextLevel());
        }

        if (secret)
        {
            if (!saveManager.secretLevelsCompleted[SceneManager.GetActiveScene().buildIndex - 37])
            {
                animator.SetBool("Activated", activated);
            }
            else
            {
                animator.SetBool("Activated", false);
            }
        }
        else
        {
            animator.SetBool("Activated", activated);
        }
    }

    IEnumerator LoadNextLevel()
    {
        GameObject screen = GameObject.Find("ScreenTransition");

        if (screen != null)
        {
            Animator screenTransition = screen.GetComponentInChildren<Animator>();

            if(screenTransition != null)
                screenTransition.SetTrigger("EndTransition");

            /*
            GameObject canvas = GameObject.Find("Canvas");
            if(canvas != null)
            {
                foreach(Transform child in canvas.transform)
                {
                    if(!child.name.Contains("ScreenTransition"))
                        child.gameObject.GetComponent<Animator>().SetTrigger("EndTransition");
                }
            }*/

            yield return new WaitForSeconds(0.6f);
        }


        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentBuildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            if(saveManager != null && currentBuildIndex < saveManager.levelsUnlocked.Length)
            {
                saveManager.levelsUnlocked[currentBuildIndex] = true;

                if(currentBuildIndex % 9 == 0 && 36 + currentBuildIndex / 9 < 40)
                {
                    saveManager.levelsUnlocked[36 + currentBuildIndex / 9] = true;
                    saveManager.secretLevelsUnlocked[currentBuildIndex / 9 - 1] = true;
                }

                saveManager.SaveGameData();
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
