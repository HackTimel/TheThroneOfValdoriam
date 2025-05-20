using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Code_Manager : MonoBehaviour
{

    [SerializeField] public Text texte;
    private string code0;
    private string mdp;
    [SerializeField] public Quets quetes2;
    [SerializeField] public  GameObject luimeme;

    public List<string> code = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        code0 = "";
        mdp = "9821";
    }

    // Update is called once per frame
    void Update()
    {
        refresh();
    }

    public void verfication()
    {
        string code_current = texte.text;
        if (code_current==mdp)
        {
            luimeme.SetActive(false);
            quetes2.code_bon = true;
        }
        else
        {
            code = new List<string>();
        }
    }

    void refresh()
    {
        code0 = "";
        foreach (var VARIABLE in code)
        {
            code0+=VARIABLE;
        }
        texte.text = code0;
    }
}
