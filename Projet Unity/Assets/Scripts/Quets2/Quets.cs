using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quets : MonoBehaviour
{
    public bool activation_Quets = false;
    private bool Etape1;
    private bool Etape2;
    private bool Etape3;
    private bool Etape4;
    private bool Etape5;
    [SerializeField] public Button Panel;
    [SerializeField] public Text texte;
    //[SerializeField] public GameObject PorteGameObject;
    [SerializeField] public GameObject CibleGameObject;
    public bool Passer_porte = false;  
    public bool porte_baisser0 = false;

    public bool fin_quetes1 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fin_quetes1)
        {
            activation_Quets = true;
            Etape1 = true;
        }

        if (Etape1)
        {
            Quetes_Fuite_Etape_1();
        }

        if (Etape2)
        {
            Quetes_Fuite_Etape_2();
        }
        //Debug.Log("PASSER PORTE+"+Passer_porte);
        //Debug.Log("PORTE BAISSER"+porte_baisser0);
    }



        public void Quetes_Fuite_Etape_1()
    {
        Panel.gameObject.SetActive(true);
        
        texte.text = "Fuis et ferme la porte.";
        texte.fontSize = 20;
        if (Passer_porte&&porte_baisser0)
        {
            Etape1 = false;
            Etape2 = true;
        }


    }

    public void Quetes_Fuite_Etape_2()
    {
        texte.text = "Prend l'un des 2 chemin et affronte les sentinelles.";
        texte.fontSize = 15;
    }
}
