using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroiteManager : MonoBehaviour
{
    [SerializeField] public Button ToucheDroite;
    [SerializeField] private DroiteComportement droiteComportement;
    [SerializeField] private PlayerMovement playerMovement;
    
    public bool changement = false;

    public int delay = 0;
    
    public bool assign = false;
    

    public string touche;
    private KeyCode key;

    // Update is called once per frame

    void Start() //ici on load les paramètres du Main Menu
    {
        touche = PlayerPrefs.GetString("PlayerDroite");
        key = GetKeyCode(touche);
        AssignerDroite(key,touche);
        droiteComportement.NewText(touche);
    }
    void Update()
    {
        
        if (delay > 0)
        {
            delay--;
        }
        if (assign && delay == 0)
        {
            AssignerDroite(key, touche);
            assign = false;
        }
        
        
        if (changement)
        {
            if (Input.anyKeyDown) //&& logique pour éviter les conflit avec le cas particulier
            {
                touche = Input.inputString;
                key = GetKeyCode(touche);
                droiteComportement.NewText(touche);
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
    
    public void ChangementDroite()
    {
        changement = true;
        droiteComportement.NewText("?");
    }
    
    public void AssignerDroite(KeyCode key,string cle)
    {
        playerMovement.moveRight = key;
        PlayerPrefs.SetString("PlayerDroite", cle);
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
