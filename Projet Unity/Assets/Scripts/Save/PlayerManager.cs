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
        if (PersitentManager.instance.hasLoaded) //vérifie si on charge une game
        {
            // Appliquer les données sauvegardées
            playerTransform.position = new Vector3(PersitentManager.instance.savedPosition[0], PersitentManager.instance.savedPosition[1], PersitentManager.instance.savedPosition[2]);
            healthpriority= PersitentManager.instance.savedHealth;
            PersitentManager.instance.hasLoaded = false; // Reset pour éviter de recharger en boucle
            health_change = true;
        }
    }
}
