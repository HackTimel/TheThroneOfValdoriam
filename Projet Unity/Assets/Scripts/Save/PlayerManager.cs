using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public HealthManager healthManager;
    public Transform playerTransform;
    public float healthpriority;
    public bool health_change = false;

    private void Start()
    {
        if (PersistentManager.instance.hasLoaded) //vérifie si on charge une game
        {
            // Appliquer les données sauvegardées
            playerTransform.position = new Vector3(PersistentManager.instance.savedPosition[0], PersistentManager.instance.savedPosition[1], PersistentManager.instance.savedPosition[2]);
            healthpriority= PersistentManager.instance.savedHealth;
            PersistentManager.instance.hasLoaded = false; // Reset pour éviter de recharger en boucle
            health_change = true;
        }
    }
}
