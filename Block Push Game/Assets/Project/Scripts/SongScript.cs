using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongScript : MonoBehaviour
{
    private AudioSource audioSource;
    [HideInInspector] public AudioClip song;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        song = audioSource.clip;

        GameObject old = GameObject.Find("OldMusicPlayer");
        if (old != null && old.GetComponent<SongScript>().song != song)
        {
            Destroy(old);
        }
        else if(old != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        gameObject.name = "OldMusicPlayer";
    }
}

