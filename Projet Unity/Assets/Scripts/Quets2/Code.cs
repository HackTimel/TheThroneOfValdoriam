using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Code : MonoBehaviour
{
    [SerializeField] public Text texte;
    [SerializeField] public Code_Manager text43;
    // Start is called before the first frame update

    private string val;

    void Start()
    {
        val = texte.text;
       
    }
   public  void ajout()
    {
        text43.code.Add(val);
    }
    
}
