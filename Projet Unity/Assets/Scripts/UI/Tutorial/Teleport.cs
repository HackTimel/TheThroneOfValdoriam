using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public Quets QUETS2;
    [SerializeField] public GameObject destination;
    [SerializeField] public GameObject depart;
    [SerializeField] StartClass instance;

    private bool hasTeleported = false;

    void Start()
    {
        player = instance.player;
    }

    void Update()
    {
        // Assure que player est bien assigné dynamiquement
        player = instance.player;

       
        // Vérifie si la téléportation doit avoir lieu
        if ( Vector3.Distance(player.transform.position, depart.transform.position) < 3f)
        {
            // Téléporte le joueur à la position de "destination"
            player.transform.position = destination.transform.position;

            // Active la quête
            QUETS2.activation_Quets = true;

            // Marque comme déjà téléporté
            hasTeleported = true;
        }
    }
}