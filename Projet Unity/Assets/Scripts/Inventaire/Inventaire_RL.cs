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
    public Item_Scipt_RL _itemSciptRl_current; //public pour debug
    [SerializeField] public Sprite Transparent;
     [SerializeField] private Transform Drop_Point;
     
     /*
      Champs pour le système d'équipement
      */

     public bool Is_Equip; //permet de savoir si on effectue les actions depuis le slot "équipé"
     [SerializeField] private Transform Equiper_Point;
     [SerializeField] private GameObject equip_panel; //pour l activer quand on équipe un objet
     public Transform inventaire_slot_RL_EQUIP;
     public Item_Scipt_RL _itemSciptRl_current_EQUIPED;
     
     [SerializeField] private GameObject action_Panel_EQUIP;
    
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
        if (Is_Equip)
        {
            equip_panel.SetActive(true);
        }
        UnlockCursor(); // Déverrouille le curseur quand l'inventaire s'ouvre
    }

    public void Close_inventory()
    {
        inventoryPanel.SetActive(false);
        action_Panel.SetActive(false);
        LockCursor(); // Verrouille le curseur quand l'inventaire se ferme
        equip_panel.SetActive(false);
    }

    public void AddItem(Item_Scipt_RL item)
    {
        Debug.Log("Ajout de: " + item.name + " | ID: " + item.GetInstanceID());
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

    public void Open_Action(Item_Scipt_RL item, GameObject slotGO)
    {
        _itemSciptRl_current = item;

        if (item == null)
            return;

        // gestion des boutons selon type
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

        RectTransform panelRect = action_Panel.GetComponent<RectTransform>();
        RectTransform canvasRect = action_Panel.transform.parent.GetComponent<RectTransform>();
        RectTransform slotRect = slotGO.GetComponent<RectTransform>();

        // On convertit la position du slot (pivot) en point local dans le canvas
        Vector2 anchoredPos = slotRect.anchoredPosition;

        // Décale vers le bas (dans l'espace local du canvas)
        anchoredPos.y += 200f; // à ajuster selon la hauteur de ton panneau
        anchoredPos.x -= 100f;

        // Positionne le panel d'action
        panelRect.anchoredPosition = anchoredPos;
    }
    
    
    public void Open_Action_EQUIPED(Item_Scipt_RL item)
    {
        _itemSciptRl_current_EQUIPED = item;
        
        if (item == null)
        {
            return; 
        }
        action_Panel_EQUIP.SetActive(true);
        Is_Equip = true;

    }

    public void Close_Action_Panel()
    {
        action_Panel.SetActive(false);
        _itemSciptRl_current = null;
    }

    public void Close_Action_EQUIP()
    {
        action_Panel_EQUIP.SetActive(false);
        _itemSciptRl_current_EQUIPED = null;
        Is_Equip = false;
    }

    public void Poser_Action_Button()
    {
        if (Is_Equip)
        {
            if (inventaire_slot_RL_EQUIP != null)
            {
                Tool_Type_Trigger slot_equip = inventaire_slot_RL_EQUIP.GetComponent<Tool_Type_Trigger>();
                if (slot_equip != null && slot_equip.item == _itemSciptRl_current)
                {
                    slot_equip.item_visuel.sprite = Transparent;
                    slot_equip.item_visuel.color = Color.clear;
                    slot_equip.item = null;
                }
            }
            _itemSciptRl_current_EQUIPED = null; //on supprime l'objet de la partie "équipé"
            action_Panel_EQUIP.SetActive(false);
            equip_panel.SetActive(false);
        }
        if (_itemSciptRl_current == null)
        {
            Debug.LogError("_itemSciptRl_current est null !");
            return;
        }

        if (_itemSciptRl_current.prefab == null)
        {
            Debug.LogError("_itemSciptRl_current.prefab est null !");
            return;
        }
        
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
        
        
        GameObject instantiate = Instantiate(_itemSciptRl_current.prefab); 
        
        instantiate.transform.SetParent(Equiper_Point, false);
        
        instantiate.transform.localPosition = Vector3.zero;
        instantiate.transform.localRotation = Quaternion.Euler(240f, 0f, 0f);
        instantiate.layer = LayerMask.NameToLayer("Default"); //pour évter de pouvoir le ramasser
        
        
        Rigidbody rb = instantiate.GetComponent<Rigidbody>(); //quand c'est équipé, c'est soumis au bras, pas a la gravité (sinon l objet tombe)
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true; 
        }
        
        
        //on passe maintenant à ce qui se passe dans l'ui
        
        equip_panel.SetActive(true);
        action_Panel_EQUIP.SetActive(false);
        if (inventaire_slot_RL_EQUIP != null)
        {
            Tool_Type_Trigger slot_equip = inventaire_slot_RL_EQUIP.GetComponent<Tool_Type_Trigger>();
            if (slot_equip != null)
            {
                slot_equip.item_visuel.sprite = _itemSciptRl_current.visuel;
                slot_equip.item_visuel.color = Color.white; // assure la visibilité
                slot_equip.item = _itemSciptRl_current;
            }
        }
        Detruire_Action_Button();
        
        /*
        Close_Action_Panel();
        */
        Is_Equip = true;
    }


    public void Desequip()
    {
        AddItem(_itemSciptRl_current_EQUIPED);
        _itemSciptRl_current_EQUIPED = null;
        Destroy(Equiper_Point.GetChild(0).gameObject);
        equip_panel.SetActive(false);
        Is_Equip = false;
    }
   
}
