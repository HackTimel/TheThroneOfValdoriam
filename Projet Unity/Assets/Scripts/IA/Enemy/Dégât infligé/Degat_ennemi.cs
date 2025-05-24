using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Degat_ennemi : MonoBehaviour
{
    public int damageAmount = 5; //degat exemple
    [SerializeField] public HealthManager Health;
    [SerializeField] public IAManager Health0;

    
    public  void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Health != null)
            {
                Health.TakeDamage(damageAmount);
            }
        }
        if (other.CompareTag("Allie"))
        {
            Health0 = other.GetComponent<IAManager>(); //alors je choppe son instance de IAManager
            if (Health0 != null)
            {
                Health0.TakeDamage(damageAmount); //et boom dégâts
            }
        }
        
        
    }
    
}
