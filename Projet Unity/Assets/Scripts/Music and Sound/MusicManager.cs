using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MusicManager : MonoBehaviour //va gérer le volume
{
    

    [SerializeField]
    public AudioSource musicSource;
    
    public AudioSource vfxSource;

    [SerializeField] public  Slider volumeSlider;//permet de stocker les changements en jeu
    [SerializeField] public  Slider sfxSlider;
    public PersistentManager persistentManager;
    public float volume;
    public float sfxVolume;
    //public PersistentManager persistentManager; //pour faire transiter les informations
    
    
    public void Start()
    {
        persistentManager = GameObject.Find("PersistentManager").GetComponent<PersistentManager>();
        if (!persistentManager.Start)
        {
            volume = persistentManager.volume;
            sfxVolume = persistentManager.sfxVolume;
        }
        else
        {
            volume = PlayerPrefs.GetFloat("MusicVolume");
            sfxVolume = PlayerPrefs.GetFloat("SFXVolume");
        }
       
        volumeSlider.value = volume; //on remet les pendules à l'heure
        sfxSlider.value = sfxVolume;

        if (musicSource.clip != null)
        {
            musicSource.Play();
        }   //LoadVolume(); //charge les paramètres lorsque l'on entre dans une nouvelle scène
    }

    void Update() //pour enregistrer la valeur
    {
        SetVolume(volumeSlider.value);
        //SetSFXVolume(sfxSlider.value);
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

   /* public void SetSFXVolume(float volume_)
    {
        sfxVolume = volume_; 

        if (vfxSource != null)
        {
            vfxSource.volume = volume_;
        }

        if (persistentManager != null)
        {
            persistentManager.sfxVolume = volume_;
        }

        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    
    }
    */



}


