using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentManager : MonoBehaviour
{
    public static PersistentManager instance;

    public float[] savedPosition = new float[3];
    public float savedHealth;
    public bool hasLoaded = false; // Indique si une sauvegarde est chargée
    public float volume;
    public float sfxVolume;
    public bool Start = true;

    public int indice_spawn;
    public int selected_character;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persiste entre les scènes
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    

    public void LoadGame(string saveName)
    {
        Start = false;
        string path = Application.persistentDataPath + "/" + $"{saveName}.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);
            
            //savedPosition = loadedData.position;
            //Debug.Log($"Position chargée : X={savedPosition[0]}, Y={savedPosition[1]}, Z={savedPosition[2]}");
            savedHealth = loadedData.health;
            
            indice_spawn = loadedData.Indice_Spawn;
            selected_character = loadedData.Selected_Character;
            hasLoaded = true;

            SceneManager.LoadScene("Scenes/Romario/map 1"); // Charge la scène de jeu
        }
        else
        {
            Debug.Log("Player Data File is empty");
        }
    }
}

