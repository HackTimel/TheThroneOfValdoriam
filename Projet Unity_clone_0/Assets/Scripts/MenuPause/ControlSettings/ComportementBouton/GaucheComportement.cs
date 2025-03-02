using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GaucheComportement : MonoBehaviour
{
    [SerializeField] public Text BoutonText; //changer le texte du bouton quand celui ci est cliqué
    [SerializeField] private  GaucheManager gaucheManager;
    
    public void WaitInput() //texte affiché une fois le bouton appuyer pour indiquer qu'il faut attribuer une touche
    {
        gaucheManager.ChangementGauche();
    }
    public void NewText(string text)
    {
        BoutonText.text = text;
    }
}
