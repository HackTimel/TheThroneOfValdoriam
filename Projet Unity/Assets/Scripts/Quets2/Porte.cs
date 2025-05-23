using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;

public class Porte : MonoBehaviour
{
    [SerializeField] public Quets Quetes2;
   

    
    private void OnTriggerEnter(Collider other)
    {
        
            Quetes2.Passer_porte = true;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
