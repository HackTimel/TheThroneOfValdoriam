using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [Header("Volume Settings")]
    [SerializeField] public TMP_Text VolumeTextValue = null;
    [SerializeField] public Slider VolumeSlider = null;
    [SerializeField] private float defaultVolume = 50;

    [SerializeField] public GameObject ConfirmationPrompt = null;

    [Header("Levels To Load")]
    public string _newGameLevel;
    private string levelToLoad;
    //[SerializeField] private GameObject noSavedGameDialog = null;


    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

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

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        VolumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }
    public void ResetButton(string MenuType)
    {
        if(MenuType == "Sound")
        {
            AudioListener.volume = defaultVolume;
            VolumeSlider.value = defaultVolume;
            VolumeTextValue.text = defaultVolume.ToString("0.0");
            
        }

    }

    public IEnumerator ConfirmationBox()
    {
        ConfirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        ConfirmationPrompt.SetActive(false);
        
    }

    
}
