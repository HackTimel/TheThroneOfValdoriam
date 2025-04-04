using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SautComportement : MonoBehaviour //le nom de classe sert juste a différencier les boutons dans l'inspector
{
    
    [SerializeField] public Text BoutonText; //changer le texte du bouton quand celui ci est cliqué
    [SerializeField] private SautManager Controller;
    
    public void WaitInput() //texte affiché une fois le bouton appuyer pour indiquer qu'il faut attribuer une touche
    {
        Controller.ChangementSauter();
    }
    public void NewText(string text)
    {
        BoutonText.text = text;
    }
    
}
