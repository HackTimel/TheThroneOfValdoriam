using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quets : MonoBehaviour
{
    public bool activation_Quets = false;
    public bool Etape1 = false;
    public bool Etape2;
    public bool Etape3;
    public bool Etape4;
    public bool Etape5;
    public bool Etape6;
    [SerializeField] public Button Panel;
    [SerializeField] public Text texte;
    //[SerializeField] public GameObject PorteGameObject;
    [SerializeField] public GameObject VagueGameObject;
    [SerializeField] public GameObject Boss;
    [SerializeField] public GameObject CibGameObject;
    public bool Passer_porte = false;  
    public bool porte_baisser0 = false;
    public bool porte_baisser1 = false;
    public bool porte_passer2 = false;
    [SerializeField] public GameObject PorteSysGameObject;
     [SerializeField] public GameObject CodedGameObject;
    public bool est_mort = false;
    public bool code_bon = false;
    private RectTransform rt;
    [SerializeField] public GameObject portail;
    [SerializeField] public GameObject EnemyGameObject;
    public bool quets3;
    public bool debut = false;
    
    
    

    public bool fin_quetes1 = false;
    // Start is called before the first frame update
    void Start()
    {
        Etape1 = false;
        Etape2 = false;
        Etape3 = false;
        Etape4= false;
        Etape5 = false;
        Etape6 = false;
        quets3 = false;
        rt = Panel.GetComponent<RectTransform>();

        // Changer la taille (largeur, hauteur)
        rt.sizeDelta = new Vector2(191, 57);
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(Passer_porte+"A");
        //Debug.Log(porte_baisser0+"b");
        
        if (debut)
        {
            
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

        Debug.Log(porte_baisser0);




    }



        public void Quetes_Fuite_Etape_1()
    {
        Panel.gameObject.SetActive(true);
        
        texte.text = "Fuis et ferme la porte.";
        texte.fontSize = 14;
        VagueGameObject.SetActive(true);
        if (Passer_porte&&porte_baisser0)
        {
            debut = false;
            Etape1 = false;
            Etape2 = true;
        }


    }

    public void Quetes_Fuite_Etape_2()
    {
        texte.text = "Traverse la foret pour atteindre la cite.";
        texte.fontSize = 14;
        if (porte_passer2)
        {
            Etape2 = false;
            Etape3 = true;
        }
    }

    
    public void Quetes_Fuite_Etape_3()
    {
        EnemyGameObject.SetActive(true);
        
        if (est_mort)
        {
            Debug.Log("est mort");
            Etape3 = false;
            Etape4 = true;
            return; // ← Arrête l'exécution ici
        }

        texte.text = "Le premier rempart a cédé sous l'armée des morts .Trouvez le code dans le château pour fermer le second rempart.";
        texte.fontSize = 12;
        rt.sizeDelta = new Vector2(265, 79);

        
            Boss.SetActive(true);
        
    }

    public void Quetes_Fuite_Etape_4()
    {
       
        Destroy(Boss);
        texte.text = "Pour sauver la ville noter le code dans le chateau,et utilise le pour fermer la porte du second rempart";
        if (porte_baisser1)
        {
            Etape4= false;
            Etape5 = true;
            return;
            
        }

       
        
    }

    public void Quetes_Fuite_Etape_5()
    {
        rt.sizeDelta = new Vector2(265, 79);
        texte.text = "Un portail est apparue defender la ville contre les vagues d'enemis";
        activation_Quets = false;
        quets3 = true;
        
    }

    public void Modif_Pos()
    {
        Vector3 position = CibGameObject.transform.position;

        position.x = 196f;  // Nouvelle valeur pour X
        position.z = 1.7f; // Nouvelle valeur pour Z

        CibGameObject.transform.position = position;
    }

    public void fermer()
    {
        CodedGameObject.SetActive(false);
    }

  
}
