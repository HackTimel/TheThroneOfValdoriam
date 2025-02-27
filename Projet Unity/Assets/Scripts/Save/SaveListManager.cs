using System;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using TMPro; 

public class SaveListManager : MonoBehaviour
{
    public GameObject saveEntryPrefab; 
    public Transform saveListContainer; 
    public Transform saveEntryContainer;
    public bool change;

    private string savePath;

    private void Start()
    {
        savePath = Application.persistentDataPath +  "/";
        LoadSaveFiles();
    }

    void Update()
    {
        if (change)
        {
            savePath = Application.persistentDataPath +  "/";
            ClearSaveEntries();  // Vide la liste des entrées existantes
            LoadSaveFiles();
            change = false;
        }
    }
    
    void ClearSaveEntries()
    {
        // Détruit tous les enfants du conteneur
        foreach (Transform child in saveEntryContainer)
        {
            Destroy(child.gameObject);
        }
    }

    void LoadSaveFiles()
    {
        if (!Directory.Exists(savePath))
            Directory.CreateDirectory(savePath);

        string[] files = Directory.GetFiles(savePath, "*.json"); 
        foreach (string file in files)
        {
            string fileName = Path.GetFileNameWithoutExtension(file);
            //if (fileName == "playerData") // Vérifier si c'est bien le fichier attendu
            //{
              //  CreateSaveEntry(fileName);
            //}
            CreateSaveEntry(Path.GetFileNameWithoutExtension(file));
        }
    }

    void CreateSaveEntry(string saveName)
    {
        Transform contentTransform = saveListContainer.Find("Viewport/Content");
        GameObject entry = Instantiate(saveEntryPrefab, contentTransform);
        entry.GetComponentInChildren<TMP_Text>().text = saveName;
        //entry.GetComponent<Button>().onClick.AddListener(() => LoadSave(saveName));
        Debug.Log(saveName);
    }
    
}