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
    [SerializeField] 
    private bool isCursorLocked = true;
    public static Inventaire_RL instance;
    [SerializeField] private GameObject action_Panel;
    [SerializeField] private GameObject Poser;
    [SerializeField] private GameObject Equiper_Arme;
    [SerializeField] private GameObject Detruire;
    [SerializeField] private GameObject Consommer;
    private Item_Scipt_RL _itemSciptRl_current;
    [SerializeField] public Sprite Transparent;
     [SerializeField] private Transform Drop_Point;

    private void Awake()
    {
        instance = this;
    }

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
        for (int i = 0; i < inventaire_slot_RL.childCount; i++)
        {
            
            Tool_Type_Trigger curent_slot =  inventaire_slot_RL.GetChild(i).GetComponent<Tool_Type_Trigger>();
            curent_slot.item_visuel.sprite = Transparent;
            curent_slot.item =null;

        }
        for (int i = 0; i <content.Count; i++)
        {
            Tool_Type_Trigger curent_slot =  inventaire_slot_RL.GetChild(i).GetComponent<Tool_Type_Trigger>();
            curent_slot.item_visuel.sprite = content[i].visuel;
            curent_slot.item = content[i];

        }
    }

    public bool Is_Full()
    {
        return INVENTAIRE_SIZE == content.Count;
    }

    public void Open_Action(Item_Scipt_RL item)
    {
        _itemSciptRl_current = item;
        
        if (item == null)
        {
           return; 
        }
        switch (item.type)
        {
            case Item_type.Arme:
                Consommer.SetActive(false);
                break;
            case Item_type.Livre_de_sort:
                Equiper_Arme.SetActive(false);
                Consommer.SetActive(false);
                break;
            case Item_type.Consomable:
                Equiper_Arme.SetActive(false);
                break;
           
        }
        action_Panel.SetActive(true);
    }

    public void Close_Action_Panel()
    {
        action_Panel.SetActive(false);
        _itemSciptRl_current = null;
    }

    public void Poser_Action_Button()
    {
        GameObject instantiate = Instantiate(_itemSciptRl_current.prefab);
        instantiate.transform.position = Drop_Point.position;
        content.Remove(_itemSciptRl_current);
        Refresh_content_RL();
        Close_Action_Panel();
    }
    public void Detruire_Action_Button()
    {
        content.Remove(_itemSciptRl_current);
        Refresh_content_RL();
        Close_Action_Panel();
        
    }
    public void Consommer_Action_Button()
    {
        Close_Action_Panel();
    }
    public void Equiper_Arme_Action_Button()
    {
        Close_Action_Panel();
    }
   
}
