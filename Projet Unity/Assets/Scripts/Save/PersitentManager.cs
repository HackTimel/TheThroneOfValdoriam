using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersitentManager : MonoBehaviour
{
    public static PersitentManager instance;

    public float[] savedPosition = new float[3];
    public float savedHealth;
    public bool hasLoaded = false; // Indique si une sauvegarde est chargée

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
    

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/playerData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);
            
            savedPosition = loadedData.position;
            savedHealth = loadedData.health;
            hasLoaded = true;

            SceneManager.LoadScene("Level1"); // Charge la scène de jeu
        }
        else
        {
            Debug.Log("Player Data File is empty");
        }
    }
}
