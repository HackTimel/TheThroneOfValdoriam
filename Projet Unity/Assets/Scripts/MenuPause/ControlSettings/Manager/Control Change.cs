using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SautManager : MonoBehaviour
{
    [SerializeField] public Button ToucheSauter;

    [SerializeField] public SautComportement sautComportement;
    [SerializeField] private PlayerMovement playerMovement;
    public bool changement = false;

    public int delay = 0;
    
    public bool assign = false;
    
    public bool assignspace = false;

    public string touche;

    private KeyCode key;

    //public void Start()
    //{
        //touche = PlayerPrefs.GetString("PlayerJump");
        //key = GetKeyCode(touche);
        //AssignerSaut(key,touche);
    //}

    public void Update()
    {
        bool different = true;
        
        if (delay > 0)
        {
            delay--;
        }
        if (assign && delay == 0)
        {
            AssignerSaut(key, touche);
            changement = false;
        }

        if (assignspace && delay == 0)
        {
            AssignerSaut(KeyCode.Space, "espace");
            changement = false;
        }
        
        if (changement)
        {
            if (Input.GetKey(KeyCode.Space)) //la touche espace n'a apparement pas de nom = cas particulier
            {
                touche = "espace";
                sautComportement.NewText(touche);
                assignspace = true;
                different = false;
                Delay(400);
            }
            if (Input.anyKeyDown && different) //&& logique pour éviter les conflit avec le cas particulier
            {
                touche = Input.inputString;
                key = GetKeyCode(touche);
                sautComportement.NewText(touche);
                assign = true;
                Delay(400);
            }
        }
    }

    public void Delay(int time)
    {
        delay = time;
    }

    public void ChangementSauter()
    {
        changement = true;
        sautComportement.NewText("?");
    }

    public void AssignerSaut(KeyCode key,string cle)
    {
        playerMovement.jump = key;
        PlayerPrefs.SetString("PlayerJump", cle);
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
        };
        
        return DicoTouche[key];
    }




}
