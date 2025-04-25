using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manger_Commadement : MonoBehaviour
{
    [SerializeField] 
    public GameObject player;
    [SerializeField] 
    public float radius;
    [SerializeField] 
    public LayerMask layer;
    [SerializeField] 
    private Transform commandement_slot;
    public Sprite transparent0;
    [SerializeField]List<Allies2> allies = new List<Allies2>(); 
    private Allies2 Allies_current;
    [SerializeField] public GameObject action_panel0;
    [SerializeField]public GameObject commandeGameObjectPanel;
    private bool isCursorLocked = true;
    public GameObject panelactivation;
    

  
    void Start()
    {
        commandeGameObjectPanel.SetActive(false);
        LockCursor(); // S'assurer que le jeu commence avec le curseur caché
    }
    public void Update()
    {
        recherche();
        ajout();
        if (Input.GetKeyDown(KeyCode.C))
        {
          
            if (commandeGameObjectPanel.activeSelf)
            {
                Close0();
            }
            else
            {
                Open0();
            }
        }


    }
    public void Open0()
    {
        panelactivation.SetActive(false);
        commandeGameObjectPanel.SetActive(true);
        UnlockCursor(); // Déverrouille le curseur quand l'inventaire s'ouvre
    }

    public void Close0()
    {
        panelactivation.SetActive(true);
        commandeGameObjectPanel.SetActive(false);
        LockCursor(); // Verrouille le curseur quand l'inventaire se ferme
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
    void ajout()
    {
        Collider[] colliders = Physics.OverlapSphere(player.transform.position, radius, layer);
        
        for (int i = 0; i < colliders.Length ; i++)
        {
            allies.Add(colliders[i].GetComponent<Alllies2_Scrpit>().allies);
            int layerID = LayerMask.NameToLayer("Allies_Comm");
            ChangeLayer(colliders[i].gameObject,layerID);
           
        }
    }

    void recherche()
    {
        for (int i = 0; i <commandement_slot.childCount ; i++)
        {
            Comm_Slot curSlot = commandement_slot.GetChild(i).GetComponent<Comm_Slot>();
            curSlot.item_visuel.sprite = transparent0;
            curSlot.allies0 = null;
        }
        for (int y = 0; y <allies.Count ; y++)
        {
            Comm_Slot curSlot = commandement_slot.GetChild(y).GetComponent<Comm_Slot>();
            curSlot.item_visuel.sprite= allies[y].visuel;
            curSlot.allies0 = allies[y];
        }
        

    }
   public  void ChangeLayer(GameObject obj, int newLayer)
    {
        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            ChangeLayer(child.gameObject, newLayer);
        }
    }


    public void Open_Action2(Allies2 allies)
    {
        Allies_current = allies;
        action_panel0.SetActive(true);
        Debug.Log("Open_Action2");
    }
    public void Close_Action_Panel2()
    {
        action_panel0.SetActive(false);
        Allies_current= null;
    }

    
}
