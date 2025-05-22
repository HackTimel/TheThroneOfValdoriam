using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZone : MonoBehaviour
{
    public AudioClip musicClip; //la musique littéralement
    
    public AudioSource audioSource; //l objet d ou voent la musique

    private void Start()
    {
        /*
        Renderer renderer = GetComponent<Renderer>();
        Color color = renderer.material.color;
        color.a = 0f; // alpha entre 0 (invisible) et 1 (opaque)
        renderer.material.color = color;
        */
      
        GetComponent<MeshRenderer>().enabled = false;

    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("la valeur audio est in");
            audioSource.clip = musicClip;
            audioSource.loop = true;
            audioSource.Play();
            
        }
    }

    public void OnTriggerExit(Collider other)
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
