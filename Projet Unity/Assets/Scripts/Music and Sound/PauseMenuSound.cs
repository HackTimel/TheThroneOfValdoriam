using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuSound : MonoBehaviour
{
    public static PauseMenuSound Instance;
 
    [SerializeField]
    private MusicLibrary musicLibrary;
    [SerializeField]
    public AudioSource musicSource;
    
    [SerializeField] public Slider volumeSlider;//permet de stocker les changements en jeu
    
    
    public void LoadVolume() //permet de garder les paramètres entre les scènes et donc le menu pause
    {
        float volume = PlayerPrefs.GetFloat("MusicVolume");
        volumeSlider.value = volume;
    }
    public Slider GetVolumeSlider()
    {
        return volumeSlider;
    }

    private void Awake()
    {
        LoadVolume(); //charge les paramètres lorsque l'on entre dans une nouvelle scène
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetVolume(volumeSlider.value);
    }
    
    public void SetVolume(float volume)
    {
        SetMusicVolume(volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    
    public void SetMusicVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = volume;
        }
    }
    
    public void PlayMusic(string trackName, float fadeDuration = 0.5f)
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop(); // Arrête la musique précédente
        }
        AudioClip nexttrack = musicLibrary.GetClipFromName(trackName); //on prend la musique en paramètre
        musicSource.clip = nexttrack;
        SetVolume(PlayerPrefs.GetFloat("MusicVolume"));
        musicSource.Play();
    }
}
