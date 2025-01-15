using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvancerManager : MonoBehaviour
{
    [SerializeField] public Button ToucheAvancer;
    [SerializeField] private AvancerComportement avancerComportement;
    [SerializeField] private PlayerMovement playerMovement;
    
    public bool changement = false;

    public int delay = 0;
    
    public bool assign = false;
    

    public string touche;
    private KeyCode key;

    // Update is called once per frame

    void Start() //ici on load les paramètres du Main Menu
    {
        touche = PlayerPrefs.GetString("PlayerAvancer");
        key = GetKeyCode(touche);
        AssignerAvancer(key,touche);
        avancerComportement.NewText(touche);
    }
    void Update()
    {
        
        if (delay > 0)
        {
            delay--;
        }
        if (assign && delay == 0)
        {
            AssignerAvancer(key, touche);
            assign = false;
        }
        
        
        if (changement)
        {
            if (Input.anyKeyDown) //&& logique pour éviter les conflit avec le cas particulier
            {
                touche = Input.inputString;
                key = GetKeyCode(touche);
                avancerComportement.NewText(touche);
                assign = true;
                Delay(100);
                changement = false;
            }
        }
    }
    
    public void Delay(int time)
    {
        delay = time;
    }
    
    public void ChangementAvancer()
    {
        changement = true;
        avancerComportement.NewText("?");
    }
    
    public void AssignerAvancer(KeyCode key,string cle)
    {
        playerMovement.moveForward = key;
        PlayerPrefs.SetString("PlayerAvancer", cle);
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
