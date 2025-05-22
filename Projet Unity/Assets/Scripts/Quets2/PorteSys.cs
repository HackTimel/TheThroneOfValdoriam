using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteSys : MonoBehaviour
{
    [SerializeField] public GameObject Player;
     [SerializeField] public float Distance;
     public bool porte_baisser = false;
     [SerializeField] public GameObject Monter;
     [SerializeField] public GameObject Baisser;
     [SerializeField] public GameObject Monter0;
     [SerializeField] public GameObject Baisser0;
     [SerializeField] public GameObject PorteGameObject;
     [SerializeField] public GameObject Localisation;
     [SerializeField] public Quets Quetes2;
    

    // Update is called once per frame
    void Update()
    {
       
        Ouverture_Port();
        if (porte_baisser)
        {
            Quetes2.porte_baisser0 = true;
        }
        else
        {
            Quetes2.porte_baisser0 = false;
        }
    }
    public void Ouverture_Port()
    {
        if (Vector3.Distance(Player.transform.position, Localisation.transform.position) < Distance)
        {
            if (!porte_baisser)
            {
           
                Monter0.SetActive(true);
                Baisser0.SetActive(true);
                if (Input.GetKeyDown(KeyCode.V))
                {
                    Debug.Log("B"+Quetes2.porte_baisser0);
                  
                    porte_baisser = true;
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
                
                    porte_baisser = false;
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
