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
    public static Manger_Commadement instance0;
    public Sprite transparent0;
    [SerializeField]List<Allies2> allies = new List<Allies2>(); 
    private Allies2 Allies_current;
    [SerializeField] public GameObject action_panel0;
    

    private void Awake()
    {
        instance0= this;
    }

    private void Update()
    {
        recherche();
     
        
            ajout();
         
    }
    void ajout()
    {
        Collider[] colliders = Physics.OverlapSphere(player.transform.position, radius, layer);
        
        for (int i = 0; i < colliders.Length ; i++)
        {
            allies.Add(colliders[i].GetComponent<Alllies2_Scrpit>().allies);
            Destroy(colliders[i].gameObject);
        }
    }

    void recherche()
    {
        for (int i = 0; i <commandement_slot.childCount ; i++)
        {
            Comm_Slot curSlot = commandement_slot.GetChild(i).GetComponent<Comm_Slot>();
            curSlot.item_visuel = transparent0;
            curSlot.allies0 = null;
        }
        for (int y = 0; y <allies.Count ; y++)
        {
            Comm_Slot curSlot = commandement_slot.GetChild(y).GetComponent<Comm_Slot>();
            curSlot.item_visuel = allies[y].visuel;
            curSlot.allies0 = allies[y];
        }
        

    }

    public void Open_Action2(Allies2 allies)
    {
        Allies_current = allies;
        action_panel0.SetActive(true);
    }
    public void Close_Action_Panel2()
    {
        action_panel0.SetActive(false);
        Allies_current= null;
    }

    
}
