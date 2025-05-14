using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Zone_de_parole : MonoBehaviour
{
    public GameObject bulle_de_dialogue; //a activer lors de la présence d'un joueur

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bulle_de_dialogue.SetActive(true);
            Bulle_de_dialogue bulle = bulle_de_dialogue.GetComponent<Bulle_de_dialogue>();
            bulle.GenerateDialog();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bulle_de_dialogue.SetActive(false);
        }
    }
}
