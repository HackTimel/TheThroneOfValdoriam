using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummySound : MonoBehaviour
{

    public GameObject dummy_to_destroy;
    public AudioSource audio_source;
    public AudioClip Destruction_sound;
    public bool death = false;
    
    public void Destruction()
    {
        Destroy(dummy_to_destroy);
        audio_source.PlayOneShot(Destruction_sound);
        death = true;
    }
}
