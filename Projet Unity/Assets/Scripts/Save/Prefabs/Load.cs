using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.UI;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    public PersistentManager persistentManager;
    
    private TMP_Text buttonText;
    
    [SerializeField]private Button button; //lui même pour gérer le cas OnClick ("qui visiblement ne marche pas")
    
    void Start()
    {
        buttonText = GetComponentInChildren<TMP_Text>();
        if (button != null)
        {
            button.onClick.AddListener(LoadSave);
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
    
    public void LoadSave()
    {
        if (buttonText != null)
        {
            string saveName = buttonText.text;
            //Debug.Log("Chargement de la sauvegarde : " + saveName);
            persistentManager.LoadGame(saveName);
        }
        else
        {
            Debug.LogWarning("Aucun texte trouvé sur ce bouton !");
        }
    }
}
