using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using TMPro; 

public class SaveListManager : MonoBehaviour
{
    public GameObject saveEntryPrefab; // Assignez le préfab dans l'inspecteur
    public Transform saveListContainer; 

    private string savePath;

    void Start()
    {
        savePath = Application.persistentDataPath +  "/";
        LoadSaveFiles();

    }

    void LoadSaveFiles()
    {
        if (!Directory.Exists(savePath))
            Directory.CreateDirectory(savePath);

        string[] files = Directory.GetFiles(savePath, "*.json"); // Assurez-vous que vos sauvegardes sont en JSON
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