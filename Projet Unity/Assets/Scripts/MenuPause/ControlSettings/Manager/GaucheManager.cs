using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GaucheManager : MonoBehaviour
{
    [SerializeField] public Button ToucheGauche;
    [SerializeField] private GaucheComportement gaucheComportement;
    [SerializeField] private PlayerMovement playerMovement;
    
    public bool changement = false;

    public int delay = 0;
    
    public bool assign = false;
    

    public string touche;
    private KeyCode key;

    // Update is called once per frame

    void Start() //ici on load les paramètres du Main Menu
    {
        touche = PlayerPrefs.GetString("PlayerGauche");
        key = GetKeyCode(touche);
        AssignerGauche(key,touche);
        gaucheComportement.NewText(touche);
    }
    void Update()
    {
        
        if (delay > 0)
        {
            delay--;
        }
        if (assign && delay == 0)
        {
            AssignerGauche(key, touche);
            assign = false;
            changement = false;
        }
        
        
        if (changement)
        {
            if (Input.anyKeyDown) //&& logique pour éviter les conflit avec le cas particulier
            {
                touche = Input.inputString;
                key = GetKeyCode(touche);
                gaucheComportement.NewText(touche);
                assign = true;
                Delay(400);
                changement = false;
            }
        }
    }
    
    public void Delay(int time)
    {
        delay = time;
    }
    
    public void ChangementGauche()
    {
        changement = true;
        gaucheComportement.NewText("?");
    }
    
    public void AssignerGauche(KeyCode key,string cle)
    {
        playerMovement.moveLeft = key;
        PlayerPrefs.SetString("PlayerGauche", cle);
    }
    
    public KeyCode GetKeyCode(string key)
    {
        Dictionary<string, KeyCode> DicoTouche = new Dictionary<string, KeyCode>()
        {
            { "a", KeyCode.A },
            { "b", KeyCode.B },
            { "c", KeyCode.C },
            { "d", KeyCode.D },
            { "e", KeyCode.E },
            { "f", KeyCode.F },
            { "g", KeyCode.G },
            { "h", KeyCode.H },
            { "i", KeyCode.I },
            { "j", KeyCode.J },
            { "k", KeyCode.K },
            { "l", KeyCode.L },
            { "m", KeyCode.M },
            { "n", KeyCode.N },
            { "o", KeyCode.O },
            { "p", KeyCode.P },
            { "q", KeyCode.Q },
            { "r", KeyCode.R },
            { "s", KeyCode.S },
            { "t", KeyCode.T },
            { "u", KeyCode.U },
            { "v", KeyCode.V },
            { "w", KeyCode.W },
            { "x", KeyCode.X },
            { "y", KeyCode.Y },
            { "z", KeyCode.Z },
            {"shift", KeyCode.LeftShift}
        };
        
        return DicoTouche[key];
    }
}
