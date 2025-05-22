using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

public class DummyTuto : MonoBehaviour
{
    [SerializeField] Image healthBar;

    public float currentHealth;
    
    public float damage;

    public DummySound dummySound;
    //healthBar.fillAmount = newValue / maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 100f;
        damage = 34f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            currentHealth -= damage;
            healthBar.fillAmount = currentHealth / 100f;
            if (currentHealth <= 0)
            {
                dummySound.Destruction();
            }
        }
    }

    
}
