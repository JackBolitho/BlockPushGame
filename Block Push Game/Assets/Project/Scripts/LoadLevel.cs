using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public int index;
    [HideInInspector] public bool unlocked = false;
    public GameObject lockImage;
    public GameObject numberText;
    public bool alwaysUnlocked = false;

    private Animator screenTransition;

    private Button button;

    private void Start()
    {   
        button = GetComponent<Button>();

        GameObject screen = GameObject.Find("ScreenTransition");
        if(screen != null)
        {
            screenTransition = screen.GetComponentInChildren<Animator>();
        }
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
        if (unlocked || alwaysUnlocked)
        {
            if (numberText != null && lockImage != null)
            {
                numberText.SetActive(true);
                lockImage.SetActive(false);
            }
            button.interactable = true;
        }
        else
        {
            if (numberText != null && lockImage != null)
            {
                numberText.SetActive(false);
                lockImage.SetActive(true);
            }
            button.interactable = false;
        }
    }
}
