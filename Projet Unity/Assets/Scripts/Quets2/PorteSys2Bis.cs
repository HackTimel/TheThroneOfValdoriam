using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteSys2Bis : MonoBehaviour
{
    [SerializeField] public GameObject Player;
    [SerializeField] public float Distance;
    public bool porte_baisser = false;
    [SerializeField] public GameObject Monter0;
    [SerializeField] public GameObject Baisser0;
    [SerializeField] public GameObject CodeGameObject;
    [SerializeField] public GameObject Localisation;
    [SerializeField] public Quets Quetes2;
    [SerializeField] public GameObject SysGameObject;
    [SerializeField] public GameObject SysGameObject0;
    [SerializeField] public GameObject SysGameObject1;


    // Update is called once per frame
    void Update()
    {
        Ouverture_Port();
        if (Quetes2.code_bon)
        {
            SysGameObject.SetActive(false);
            SysGameObject0.SetActive(false);
            SysGameObject1.SetActive(true);
            
        }

    }

    public void Ouverture_Port()
    {
        if (Vector3.Distance(Player.transform.position, Localisation.transform.position) < Distance)
        {
           


            Monter0.SetActive(true);
            Baisser0.SetActive(true);
            if (Input.GetKeyDown(KeyCode.V))
            {
                CodeGameObject.SetActive(true);
                Monter0.SetActive(false);
                Monter0.SetActive(false);
            }
          


        }
        else
        {
            Monter0.SetActive(false);
            Monter0.SetActive(false);
           
        }
    }
}

