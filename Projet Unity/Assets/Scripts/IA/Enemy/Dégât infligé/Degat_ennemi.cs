using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Degat_ennemi : MonoBehaviour
{
    public int damageAmount = 10; //degat exemple
    [SerializeField] public GameObject Health;
    [SerializeField] public IAManager Health0;

    
    public  void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Health != null)
            {
                HealthManager playerHealthScript = Health.GetComponent<HealthManager>();
                playerHealthScript.TakeDamage(damageAmount);
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
