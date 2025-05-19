using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Degat_ennemi : MonoBehaviour
{
    public int damageAmount = 10; //degat exemple
    [SerializeField] public GameObject Health;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Health != null)
            {
                HealthManager playerHealthScript = Health.GetComponent<HealthManager>();
                playerHealthScript.TakeDamage(damageAmount);
            }
        }
    }
}
