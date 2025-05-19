using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quets : MonoBehaviour
{
    public bool activation_Quets = false;
    public bool Etape1;
    public bool Etape2;
    public bool Etape3;
    public bool Etape4;
    public bool Etape5;

    public bool fin_quetes1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fin_quetes1)
        {
            activation_Quets = true;
        }

        if (Etape1)
        {
            Quetes_Fuite_Etape_1();
        }
    }

    public void Quetes_Fuite_Etape_1()
    {
        
    }
}
