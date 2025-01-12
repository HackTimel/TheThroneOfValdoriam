using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
 
    [SerializeField]
    private MusicLibrary musicLibrary;
    [SerializeField]
    public AudioSource musicSource;
    
    [SerializeField] public Slider volumeSlider; //permet de stocker les changements en jeu
    [SerializeField] public Slider sfxSlider;

    public Slider GetVolumeSlider()
    {
        return volumeSlider;
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

     void Update() //pour enregistrer la valeur
    {
        SetVolume(volumeSlider.value);
    }

    public void SetVolume(float volume)
    {
        SetMusicVolume(volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
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
 
    IEnumerator AnimateMusicCrossfade(AudioClip nextTrack, float fadeDuration = 0.5f) //pour tenter un effet de morphose entre les différents thèmes
    {
        float percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / fadeDuration;
            yield return null;
        }
 
        musicSource.clip = nextTrack;
        musicSource.Play();
 
        percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / fadeDuration;
            yield return null;
        }
    }
    
    public void SetMusicVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = volume;
        }
    }
}


//yt : Raycastly
