using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprintComportement : MonoBehaviour
{
    [SerializeField] public Text BoutonText; //changer le texte du bouton quand celui ci est cliqué
    [SerializeField] private  SprintManager sprintManager;
    
    public void WaitInput() //texte affiché une fois le bouton appuyer pour indiquer qu'il faut attribuer une touche
    {
        sprintManager.ChangementSprinter();
    }
    public void NewText(string text)
    {
        BoutonText.text = text;
    }
}
