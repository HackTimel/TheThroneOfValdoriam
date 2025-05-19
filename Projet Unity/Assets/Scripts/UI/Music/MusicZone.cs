using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZone : MonoBehaviour
{
    public AudioClip musicClip; //la musique littéralement
    
    public AudioSource audioSource; //l objet d ou voent la musique
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("la valeur audio est in");
            audioSource.clip = musicClip;
            audioSource.Play();
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
