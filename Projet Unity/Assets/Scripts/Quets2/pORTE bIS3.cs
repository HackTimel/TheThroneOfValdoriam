using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;

public class pORTEbIS3 : MonoBehaviour
{
     [SerializeField][CanBeNull] public GameObject Player;
     [SerializeField] public float Distance;
     public bool porte_baisser03 = false;
     [SerializeField] public GameObject Monter;
     [SerializeField] public GameObject Baisser;
     [SerializeField] public GameObject Monter0;
     [SerializeField] public GameObject Baisser0;
     [SerializeField] public GameObject PorteGameObject;
     [SerializeField] public GameObject Localisation;
     [SerializeField] public Quets Quetes2;
     [SerializeField][CanBeNull] public StartClass instance;

     void Start()
     {
         Player = instance.player;
     }
    // Update is called once per frame
    void Update()
    {
        Player = instance.player;
       
        Ouverture_Port();
        if (porte_baisser03)
        {
            Quetes2.porte_baisser1 = true;
        }
        else
        {
            Quetes2.porte_baisser1 = false;
        }
        Debug.Log(porte_baisser03);
    }
    public void Ouverture_Port()
    {
        if (Vector3.Distance(Player.transform.position, Localisation.transform.position) < Distance)
        {
           
            if (!porte_baisser03)
            {
           
                Monter0.SetActive(true);
                Baisser0.SetActive(true);
                if (Input.GetKeyDown(KeyCode.V))
                {
                    
                  
                    porte_baisser03 = true;
                    Debug.Log("C"+Quetes2.porte_baisser0);
                    Vector3 position = PorteGameObject.transform.position;
                    position.y = -0.7f; 
                    PorteGameObject.transform.position = position;
                    
                    Monter0.SetActive(false);
                    Baisser0.SetActive(false);

                }
                
            }
            else 
            {
                Monter.SetActive(true);
                Baisser.SetActive(true);
                if(Input.GetKeyDown(KeyCode.B))
                {
                
                    porte_baisser03 = false;
                    Vector3 position = PorteGameObject.transform.position;
                    position.y = 4.7f; 
                    PorteGameObject.transform.position = position;
                    Monter.SetActive(false);
                    Baisser.SetActive(false);
                }
            }
           
        }
        else
        {
            Monter.SetActive(false);
            Monter0.SetActive(false);
            Baisser.SetActive(false);
            Baisser0.SetActive(false);
        }
    }
}
