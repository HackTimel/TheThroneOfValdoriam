using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [Header("Volume Settings")] //paramètres des slides (Leewen)
    [SerializeField] public AudioMixer audioMixer;
    [SerializeField]public Slider musicSlider;
    [SerializeField]public Slider sfxSlider;
    [SerializeField]public float defaultVolume = 0.4f;

    public Slider MusicSlider
    {
        get => musicSlider;
        set => musicSlider = value;
    }

    public Slider SfxSlider
    {
        get => sfxSlider;
        set => sfxSlider = value;
    }
    

    
    [SerializeField] public GameObject ConfirmationPrompt = null;

    [Header("Levels To Load")]
    public string _newGameLevel;
    private string levelToLoad;
    //[SerializeField] private GameObject noSavedGameDialog = null;

    
    

    public void Start() //Pour la musique
    {
        //LoadVolume(); //plus tard pour le système de sauvegarde des paramètres
        MusicManager.Instance.PlayMusic("Menu");
        
    }


    public void StopMenuTheme()
    {
        MusicManager manager = MusicManager.Instance;
        manager.SetMusicVolume(0); //coupe la musique lors du démarrage du jeu
    }
    //public void Play()
    //{
        //SceneManager.LoadScene(_newGameLevel, "Cross Fade");
        //MusicManager.Instance.PlayMusic("Menu");
    //}
    // Pour la transition Menu => jeu plus tard
    

    public void LoadGameDialogYes()
    {
        if(PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            //noSavedGameDialog.SetActive(true);
        }

    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void UpdateMusicVolume(float volume) //slider Music
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }
    
    
    public void UpdateSoundVolume(float volume) //slider SFX
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }
    
    
    public void SaveVolume()
    {
        audioMixer.GetFloat("MusicVolume", out float musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
 
        audioMixer.GetFloat("SFXVolume", out float sfxVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }
 
    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");

    }
    
    public void ResetButton(string MenuType)
    {
        if(MenuType == "Sound")
        {
        }

    }

    public IEnumerator ConfirmationBox()
    {
        ConfirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        ConfirmationPrompt.SetActive(false);
        
    }

    
}
