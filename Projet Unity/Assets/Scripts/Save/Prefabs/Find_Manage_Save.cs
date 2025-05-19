using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Find_Manage_Save : MonoBehaviour
{
    [SerializeField] public GameObject sauvegarde;

    [SerializeField] public Load script;
    [SerializeField] public GameObject loadsave;
    [SerializeField] public GameObject deletesave;
    [SerializeField] public SaveListManager saveListManager;
    // Start is called before the first frame update
    void Update()
    {
        GameObject[] allSaves = GameObject.FindGameObjectsWithTag("SaveButton"); // récupère tous les boutons de sauvegarde avec le tag mis dans le prefab
        sauvegarde = null; // réinitialise sauvegarde

        foreach (GameObject temp in allSaves)
        {
            script = temp.GetComponent<Load>();
            if (script != null && script.selected) 
            {
                sauvegarde = temp;
                loadsave.SetActive(true);
                deletesave.SetActive(true);
                break; 
            }
        }
        
        if (sauvegarde is null)
        {
            loadsave.SetActive(false);
            deletesave.SetActive(false);
        }
    }

    // Update is called once per frame
    public void Charger()
    {
        script.LoadSave();
    }

    public void Supprimer()
    {
        script.DeleteSave();
        saveListManager.change = true;
    }
}
