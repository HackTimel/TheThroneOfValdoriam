using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beggining : MonoBehaviour
{
    [SerializeField] public Quets Quetes2;
 
     
     private void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.CompareTag("Player"))
         {
             Quetes2.debut = true;
         }
        
         
     }
}
