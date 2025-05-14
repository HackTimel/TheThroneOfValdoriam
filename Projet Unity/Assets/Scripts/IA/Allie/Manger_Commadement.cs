using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

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
    [SerializeField] public List<(Allies2, GameObject)> allies = new List<(Allies2, GameObject)>();
    public  Allies2 Allies_current;
    public GameObject allies1_Current;
    [SerializeField] public GameObject action_panel0;
    [SerializeField]public GameObject commandeGameObjectPanel;
    private bool isCursorLocked = true;
    public GameObject panelactivation;
    [SerializeField]public static Manger_Commadement instance0;
    [SerializeField] public float distance;
    [SerializeField] public GameObject drop;
    [SerializeField] public float IA_Speed;
    private bool suivre = false;
    [SerializeField] public GameObject drapeau;
    private bool active;
    [SerializeField] public BasePlayer mouvement;
    private bool activation;
    private GameObject val;
    public Collider[] colliders;
    
    



    public void Awake()
    {
        instance0 = this;
    }
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

        if (activation)
        {
           deplcement_Object(val); 
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
      colliders = Physics.OverlapSphere(player.transform.position, radius, layer);
        
    }
    void ajout0()
    {
         colliders = Physics.OverlapSphere(player.transform.position, radius, layer);
        
        for (int i = 0; i < colliders.Length ; i++)
        {
            allies.Add((colliders[i].GetComponent<Alllies2_Scrpit>().allies,colliders[i].gameObject));
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
            curSlot.allies1 = null;
        }
        for (int y = 0; y <allies.Count ; y++)
        {
            Comm_Slot curSlot = commandement_slot.GetChild(y).GetComponent<Comm_Slot>();
            curSlot.item_visuel.sprite= allies[y].Item1.visuel;
            curSlot.allies0 = allies[y].Item1;
            curSlot.allies1 = allies[y].Item2;
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


    public void Open_Action2(Allies2 allies2,GameObject allies1)
    {
        Allies_current = allies2;
        allies1_Current = allies1;
        if (Allies_current == null)
        {
            Debug.Log("Allies_current == null");
            return; 
        }
        if (allies1_Current == null)
        {
            Debug.Log("allies1_Current == null");
            return; 
        }
        action_panel0.SetActive(true);
    }
    public void Close_Action_Panel2()
    {
        action_panel0.SetActive(false);
        Allies_current= null;
    }

    public void Active_Suivre_Player()
    {
        
        IA_Allie_Comportement val = allies1_Current.GetComponent<IA_Allie_Comportement>();
        if ( val.Is_Suivre)
        {
            val.Is_Suivre = false;
        }
        else
        {
            val.Is_Suivre = true;
            val.Is_Suivre0 = false;  
        }
     
        Close_Action_Panel2();
    }

    public void Open_deplacement()
    {
        
         val = Instantiate( drapeau,drop.transform.position,drop.transform.rotation);
        active = true;
        activation = true;
        deplcement_Object(val);
        Close_Action_Panel2();
    }

    public void deplcement_Object(GameObject obj)
    {
        if (active)
        {
            mouvement.enabled = false;
         
            if (Input.GetKey(KeyCode.UpArrow))
            {
                obj.transform.Translate(Vector3.forward * Time.deltaTime * 5);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                obj.transform.Translate(Vector3.back * Time.deltaTime * 5);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                obj.transform.Translate(Vector3.left * Time.deltaTime * 5);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                obj.transform.Translate(Vector3.right * Time.deltaTime * 5);
            }   
        }
         if (Input.GetKeyDown(KeyCode.G))
        {
            active = false;
            activation = false;
            IA_Allie_Comportement val0 = allies1_Current.GetComponent<IA_Allie_Comportement>();
            val0.Objectif = obj.transform;
            val0.Is_Suivre0 = true;
            val0.Is_Suivre = false;
            val.GetComponent<MeshRenderer>().enabled = false;
            mouvement.enabled = true;
            Debug.Log("ACRI");



        }

    }

    
  

   

    
}
