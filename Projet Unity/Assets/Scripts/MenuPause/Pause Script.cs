using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

    [SerializeField]public GameObject pauseMenu; 
    // Start is called before the first frame update
    
    public static bool paused = false; //permet à la touche échap de pouvoir entrer et quitter le menu pause et static permet d'avoir son statut pour arreter correctement les inputs du jeu
    
    public GameObject optionsMenuContainer =  GameObject.Find("OptionsMenuContainer"); // objet à afficher (OptionsMenuContainer)
    private bool isOptionsMenuVisible = false; //menu au debut fermé.
    
    
    void Start()
    {
        pauseMenu.SetActive(false); //rend l'objet inactif aka le menu pause au démarrage (on commence pas en pause)
        PauseMenuSound.Instance.PlayMusic("Level1");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(PlayerMovement.pause))
        {
            if (!paused)
            {
                Debug.Log("detectedescape");
                PauseGame();
            }

            else
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true); //rend l'objet menu actif (on voit les options)
        paused = true;
        Time.timeScale = 0; //on freeze le jeu
        
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1; //on remet les pendules à l'heure.
        paused = false;
    }

    public void Options() //explicite pour les autres et pour l'inspector
    {
        ToggleOptionsMenu();
    }
    
    public void ToggleOptionsMenu() //en cours
    {
        if (!isOptionsMenuVisible)
        {
            // charger la scène "MainMenu" en mode additive (remplace pas la scène actuelle)
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
            
            //ont trouve l'objet "OptionsMenuContainer" dans la scène "MainMenu"
            optionsMenuContainer.SetActive(true); // Afficher l'objet dans la scène
            isOptionsMenuVisible = true;
        }
        else
        {
            // Masquer l'objet et éventuellement décharger la scène "MainMenu"
            optionsMenuContainer.SetActive(false);
            SceneManager.UnloadSceneAsync("MainMenu"); // Décharger la scène si elle n'est plus nécessaire
            isOptionsMenuVisible = false;
        }
    }


    public void GoMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit(); //une fois build marchera
    }
}
