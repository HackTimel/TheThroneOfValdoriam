using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Collections.Generic;
using UnityEngine;

public class Inventaire_RL : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryPanel;
    [SerializeField]
    public List<Item_Scipt_RL> content = new List<Item_Scipt_RL>();

    [SerializeField] 
    private Transform inventaire_slot_RL;

    private const int INVENTAIRE_SIZE = 35;

    private bool isCursorLocked = true; // Par défaut, le curseur est verrouillé

    void Start()
    {
        inventoryPanel.SetActive(false);
        LockCursor(); // S'assurer que le jeu commence avec le curseur caché
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isCursorLocked = true;
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isCursorLocked = false;
    }

    void Update()
    {
        // Activation/désactivation de l'inventaire
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryPanel.activeSelf)
            {
                Close_inventory();
            }
            else
            {
                Open_inventory();
            }
        }
        Refresh_content_RL();
        
    }

    public void Open_inventory()
    {
        inventoryPanel.SetActive(true);
        UnlockCursor(); // Déverrouille le curseur quand l'inventaire s'ouvre
    }

    public void Close_inventory()
    {
        inventoryPanel.SetActive(false);
        LockCursor(); // Verrouille le curseur quand l'inventaire se ferme
    }

    public void AddItem(Item_Scipt_RL item)
    {
        content.Add(item);
    }

    private void Refresh_content_RL()
    {
        for (int i = 0; i <content.Count; i++)
        {
            inventaire_slot_RL.GetChild(i).GetChild(0).GetComponent<Image>().sprite = content[i].visuel;
        }
    }

    public bool Is_Full()
    {
        return INVENTAIRE_SIZE == content.Count;
    }
}
