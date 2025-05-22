using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class MusicLibrary : MonoBehaviour
{
    public AudioClip audioClip1;
    MusicManager musicManager;

    private void Awake()
    {
        musicManager.musicSource.clip = audioClip1;
    }
}
