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
     [SerializeField] public GameObject Boss;
    public bool Passer_porte = false;  
    public bool porte_baisser0 = false;
    public bool porte_baisser1 = false;
    public bool porte_passer2 = false;
    [SerializeField] public GameObject PorteSysGameObject;
    public bool est_mort = false;
    public bool code_bon = false;
    
    

    public bool fin_quetes1 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(Passer_porte+"A");
        //Debug.Log(porte_baisser0+"b");
        
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

        if (Etape3)
        {
            Quetes_Fuite_Etape_3();
        }

        if (Etape4)
        {
            Quetes_Fuite_Etape_4();
        }

        if (Etape5)
        {
            Quetes_Fuite_Etape_5();
        }
       
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
        if (porte_passer2)
        {
            Etape2 = false;
            Etape3 = true;
        }
    }

    
    public void Quetes_Fuite_Etape_3()
    {
        if (est_mort)
        {
            Debug.Log("est mort");
            Etape3 = false;
            Etape4 = true;
            return; // ← Arrête l'exécution ici
        }

        texte.text = "Le premier rempart a cédé sous l'armée des morts.\n" +
                     "Trouvez le code dans le château pour fermer le second rempart.";
        texte.fontSize = 15;

        if (Boss != null)
        {
            Boss.SetActive(true);
        }
    }

    public void Quetes_Fuite_Etape_4()
    {
       
        Destroy(Boss);
        texte.text = "Pour sauver la ville noter le code dans le chateau,et utilise le pour fermer la porte du second rempart";
        if (porte_baisser1)
        {
            Etape4= false;
            Etape5 = true;
            
        }
    }

    public void Quetes_Fuite_Etape_5()
    {
        texte.text = "Fin De Quetes";
    }
}
