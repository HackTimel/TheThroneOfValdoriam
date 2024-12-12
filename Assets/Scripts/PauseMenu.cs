using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject PauseMenu;
    private bool isPaused;

    void Start()
    {
        if (PauseMenu == null)
        {
            Debug.LogWarning("PauseMenu is not assigned in the inspector.");
            return;
        }
        
        PauseMenu.SetActive(false);
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        if (PauseMenu != null) 
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }

    private void ResumeGame()
    {
        if (PauseMenu != null) 
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
    }
}
