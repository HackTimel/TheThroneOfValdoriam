using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using Unity.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Load : MonoBehaviour, IDeselectHandler
{
    public PersistentManager persistentManager;

    public bool selected;
    
    private TMP_Text buttonText;
    
    [SerializeField]private Button button; //lui même pour gérer le cas OnClick ("qui visiblement ne marche pas")
    
    void Start()
    {
        buttonText = GetComponentInChildren<TMP_Text>();
        if (button != null)
        {
            button.onClick.AddListener(selectIt);
        }
        // trouver persistent manager car impossible dans l editor
        if (persistentManager == null)
        {
            persistentManager = FindObjectOfType<PersistentManager>();
        }
    
        if (persistentManager == null)
        {
            Debug.LogError("PersistentManager non trouvé dans la scène !");
        }
    }

    void Update()
    {
        
        if (selected)
        {
            GameObject[] allSaves = GameObject.FindGameObjectsWithTag("SaveButton");
            foreach (GameObject temp in allSaves)
            {
                Load script = temp.GetComponent<Load>();
                if (temp != gameObject)
                {
                    script.selected = false;
                }
            }
            button.image.color = Color.green; 
        }

        if (!selected)
        {
            button.image.color = Color.black;
        }
    }

    public void selectIt()
    {
        selected = true;
    }
    
    public void LoadSave()
    {
        if (buttonText != null)
        {
            string saveName = buttonText.text;
            
            persistentManager.LoadGame(saveName);
        }
        else
        {
            Debug.LogWarning("Aucun texte trouvé sur ce bouton !");
        }
    }
    
    public void DeleteSave()
    {
        if (buttonText != null)
        {
            string saveName = buttonText.text;
            string path = Application.persistentDataPath + "/" + $"{saveName}.json";
            if (File.Exists(path))
            {
                File.Delete(path);
                Debug.Log("Sauvegarde supprimée : " + path);
            }
        }
        Destroy(gameObject);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (selected && Input.GetMouseButtonDown(0)) 
        {
            GameObject selectedObject = EventSystem.current.currentSelectedGameObject;

            if (selectedObject != gameObject) 
            {
                selected = false;
            }
        }
    }
}
