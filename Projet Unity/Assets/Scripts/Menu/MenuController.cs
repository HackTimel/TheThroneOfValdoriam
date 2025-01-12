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
using System.Threading;
using UnityEngine.Serialization;

public class MenuController : MonoBehaviour
{
    [Header("Volume Settings")] //paramètres des slides (Leewen)
    [SerializeField] public AudioMixer audioMixer;
    [SerializeField]public float defaultVolume = 0.6f;
    [SerializeField] public float volumeChanged = 0.6f;

    
    MusicManager manager = new MusicManager();
    
    

    
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
    


    public void StopMenuTheme() //arrete le menu du jeu puis initialise la transition vers le thème du jeu
    {
        //manager.SetMusicVolume(0); // coupe la musique lors du démarrage du jeu
        int milliseconds = 2000;
        Thread.Sleep(milliseconds);
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
    
    
    public void ResetMusic(string MenuType)
    {
        //manager.SetMusicVolume(defaultVolume);
    }

    public IEnumerator ConfirmationBox()
    {
        ConfirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        ConfirmationPrompt.SetActive(false);
        
    }

    
}




