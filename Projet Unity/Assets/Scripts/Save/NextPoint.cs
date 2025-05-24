using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPoint : MonoBehaviour
{
    public int delay;
    public PlayerDataManager save_manager;
    public bool HasStepped = false;
    public GameObject chargement;
    
    
    public HealthManager health;
    public GameObject self;

    public void Update()
    {
        if (HasStepped)
        {
            delay++;
            if (delay % 200 == 0)
            {
                HasStepped = false;
                delay = 0;
                chargement.SetActive(false);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            save_manager.indice_savepoint += 1;
            HasStepped = true;
            chargement.SetActive(true);
            Debug.Log(save_manager.indice_savepoint);
            health.spawn = self;
        }
    }
}
