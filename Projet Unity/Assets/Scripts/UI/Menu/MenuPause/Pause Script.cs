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
    
    public GameObject optionsMenuContainer ;//=  GameObject.Find("OptionsMenuContainer"); // objet à afficher (OptionsMenuContainer)
    private bool isOptionsMenuVisible = false; //menu au debut fermé.
    public GameObject Inventaire;
    public bool InventaireActive = false;
    
    
    void Start()
    {
        optionsMenuContainer =  GameObject.Find("OptionsMenuContainer"); // objet à afficher (OptionsMenuContainer)
        pauseMenu.SetActive(false); //rend l'objet inactif aka le menu pause au démarrage (on commence pas en pause)
        //PauseMenuSound.Instance.PlayMusic("Level1");
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        Inventaire_RL inventaire = Inventaire.GetComponent<Inventaire_RL>();
        InventaireActive = inventaire.Keep_open;
        inventaire.Close_inventory();
        UnlockCursor();
    }

    public void ResumeGame()
    {
        LockCursor();
        pauseMenu.SetActive(false);
        Time.timeScale = 1; //on remet les pendules à l'heure.
        paused = false;
        if (InventaireActive)
        {
            Inventaire_RL inventaire = Inventaire.GetComponent<Inventaire_RL>();
            inventaire.Open_inventory();
        }
       
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
            // masquer l'objet et éventuellement décharger la scène "MainMenu"
            optionsMenuContainer.SetActive(false);
            SceneManager.UnloadSceneAsync("MainMenu"); // decharger la scène si elle n'est plus nécessaire PEUT POSER SOUCIS
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
        Application.Quit(); // Quitte le jeu dans un build
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
    
    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

