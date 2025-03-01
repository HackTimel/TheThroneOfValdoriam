using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown; //variable stockant la résolution 
    private Resolution[] resolutions;
    private int currentResolutionIndex;
    
    void Start()
    {
        resolutions = Screen.resolutions; //on obtient les différentes résolutions
        resolutionDropdown.ClearOptions(); //on enlève temporairement les choix
        
        List<string> options = new List<string>(); //affiche les choix dans le dropdown
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; //écrit par exemple : 1920 x 1080
            options.Add(option); //on ajoute option à la liste des choix possibles pour la résolution
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height) //verifie si la résolution correspond à celle-ci, alors on attribut son indide au champ
            {
                currentResolutionIndex = i;
            }
        }
        
        resolutionDropdown.AddOptions(options); //on ajoute au dropdown la liste string des résolutions
        resolutionDropdown.value = currentResolutionIndex; //commence à la résolution actuelle
        resolutionDropdown.RefreshShownValue();
    }

    void Update()
    {
        Debug.Log("Resolution actuelle =" + Screen.width + "x" + Screen.height);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); //paramètre la résolution de l'écran par rapport au choix du joueur et met en plein écran
    }
}
