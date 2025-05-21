using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiPauseScript : MonoBehaviour
{

    [SerializeField]public GameObject pauseMenu; 
    // Start is called before the first frame update
    
    public static bool paused = false; //permet à la touche échap de pouvoir entrer et quitter le menu pause et static permet d'avoir son statut pour arreter correctement les inputs du jeu
    
    public GameObject optionsMenuContainer ;//=  GameObject.Find("OptionsMenuContainer"); // objet à afficher (OptionsMenuContainer)
    
    
    void Start()
    {
        optionsMenuContainer =  GameObject.Find("OptionsMenuContainer"); // objet à afficher (OptionsMenuContainer)
        pauseMenu.SetActive(false); //rend l'objet inactif aka le menu pause au démarrage (on commence pas en pause)
        //PauseMenuSound.Instance.PlayMusic("Level1");
        //Cursor.lockState = CursorLockMode.Locked; dans l'original c'est le cas mais la on a besoin de pouvoir séléctionner le mode
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
        //Time.timeScale = 0; //on freeze le jeu
        UnlockCursor();
    }

    public void ResumeGame()
    {
        LockCursor();
        pauseMenu.SetActive(false);
        //Time.timeScale = 1; //on remet les pendules à l'heure.
        paused = false;
       
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

