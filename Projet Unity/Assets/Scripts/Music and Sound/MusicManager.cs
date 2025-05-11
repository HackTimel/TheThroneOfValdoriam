using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MusicManager : MonoBehaviour //va gérer le volume
{
    

    [SerializeField]
    public AudioSource musicSource;

    [SerializeField] public  Slider volumeSlider;//permet de stocker les changements en jeu
    [SerializeField] public  Slider sfxSlider;
    public PersistentManager persistentManager;
    public float volume;
    
    //public PersistentManager persistentManager; //pour faire transiter les informations
    
    
    public void Start()
    {
        
        if (persistentManager != null && !persistentManager.Start) //si on revient au menu
        {
            volume = persistentManager.volume;
        }
        else
        {
            volume = PlayerPrefs.GetFloat("MusicVolume");
            volumeSlider.value = volume; //on remet les pendules à l'heure

            if (musicSource.clip != null)
            {
                musicSource.Play();
            }
        }
        
        
        
            //LoadVolume(); //charge les paramètres lorsque l'on entre dans une nouvelle scène
    }

    void Update() //pour enregistrer la valeur
    {
        SetVolume(volumeSlider.value);
        //persistentManager.volume = volumeSlider.value;
    }

    public void SetVolume(float volume_)
    {
        if (musicSource != null)
        {
            musicSource.volume = volume_;
            volume = volume_;
            persistentManager.volume = volume_;
        }
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    
}


//yt : Raycastly
