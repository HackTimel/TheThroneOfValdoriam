using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    [Header("Menu GameObjects")]
    public GameObject MainMenu;
    public GameObject PauseMenu;
    public GameObject DeathMenu;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        UpdateGameState(GameState.Mainmenu);
    }

    void Update()
    {
        // Toggle Pause Menu when Escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (State == GameState.Playable)
            {
                UpdateGameState(GameState.Pausemenu);
            }
            else if (State == GameState.Pausemenu)
            {
                UpdateGameState(GameState.Playable);
            }
        }
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        // Désactivez tous les menus avant de gérer le nouvel état
        if (MainMenu != null) MainMenu.SetActive(false);
        if (PauseMenu != null) PauseMenu.SetActive(false);
        if (DeathMenu != null) DeathMenu.SetActive(false);

        // Activez uniquement le menu correspondant à l'état actuel
        switch (newState)
        {
            case GameState.Mainmenu:
                HandleMainMenu();
                break;
            case GameState.Playable:
                HandlePlayable();
                break;
            case GameState.Pausemenu:
                HandlePauseMenu();
                break;
            case GameState.Deathmenu:
                HandleDeathMenu();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleMainMenu()
    {
        Debug.Log("Main Menu State");
        if (MainMenu != null) MainMenu.SetActive(true);
        Time.timeScale = 0f; // Pause le jeu dans le menu principal
        SetCursorState(true); // Affiche le curseur
    }

    private void HandlePlayable()
    {
        Debug.Log("Playable State");
        Time.timeScale = 1f; // Reprend le jeu
        SetCursorState(false); // Cache le curseur
    }

    private void HandlePauseMenu()
    {
        Debug.Log("Pause Menu State");
        if (PauseMenu != null) PauseMenu.SetActive(true);
        if (PauseMenu != null) MainMenu.SetActive(false);
        Time.timeScale = 0f; // Met le jeu en pause
        SetCursorState(true); // Affiche le curseur
    }

    private void HandleDeathMenu()
    {
        Debug.Log("Death Menu State");
        if (DeathMenu != null) DeathMenu.SetActive(true);
        Time.timeScale = 0f; // Met le jeu en pause
        SetCursorState(true); // Affiche le curseur
    }

    // Méthode publique pour démarrer le jeu à partir du menu principal
    public void StartGame()
    {
        Debug.Log("Play Button Clicked - Starting Game");
        UpdateGameState(GameState.Playable);
    }

    // Méthode publique pour activer le menu de mort
    public void TriggerDeathMenu()
    {
        UpdateGameState(GameState.Deathmenu);
    }

    // Contrôle de l'état du curseur (visible/invisible)
    private void SetCursorState(bool visible)
    {
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = visible;
    }

    public void Resume()
    {
        UpdateGameState(GameState.Playable);
    }

    public void SetMainMenu()
    {
        UpdateGameState(GameState.Mainmenu);
    }
}

public enum GameState
{
    Mainmenu,
    Playable,
    Pausemenu,
    Deathmenu
}
