using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprintManager : MonoBehaviour
{
    
    [SerializeField] public Button ToucheSprinter;
    [SerializeField] private SprintComportement sprintComportement;
    [SerializeField] private PlayerMovement playerMovement;
    
    public bool changement = false;

    public int delay = 0;
    
    public bool assign = false;
    
    public bool assignshift = false;

    public string touche;
    private KeyCode key;

    // Update is called once per frame

    void Start() //ici on load les paramètres du Main Menu
    {
        touche = PlayerPrefs.GetString("PlayerSprint");
        key = GetKeyCode(touche);
        AssignerSprint(key,touche);
        sprintComportement.NewText(touche);
    }
    void Update()
    {
        
        bool different = true;
        
        if (delay > 0)
        {
            delay--;
        }
        if (assign && delay == 0)
        {
            AssignerSprint(key, touche);
            changement = false;
        }
        
        if (assignshift && delay == 0)
        {
            AssignerSprint(KeyCode.LeftShift, touche);
            changement = false;
        }
        
        
        if (changement)
        {
            if (Input.GetKey(KeyCode.LeftShift)) //la touche espace n'a apparement pas de nom = cas particulier
            {
                touche = "shift";
                sprintComportement.NewText(touche);
                assignshift = true;
                different = false;
                Delay(400);
            }
            if (Input.anyKeyDown && different) //&& logique pour éviter les conflit avec le cas particulier
            {
                touche = Input.inputString;
                key = GetKeyCode(touche);
                sprintComportement.NewText(touche);
                assign = true;
                Delay(400);
            }
        }
    }
    
    public void Delay(int time)
    {
        delay = time;
    }
    
    public void ChangementSprinter()
    {
        changement = true;
        sprintComportement.NewText("?");
    }
    
    public void AssignerSprint(KeyCode key,string cle)
    {
        playerMovement.sprintKey = key;
        PlayerPrefs.SetString("PlayerSprint", cle);
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
