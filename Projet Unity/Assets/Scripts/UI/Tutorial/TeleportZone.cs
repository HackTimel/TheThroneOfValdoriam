using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TeleportZone: MonoBehaviour
{
    
    public GameObject teleportZone; // l'autre destination
    public bool teleportZoneOn;
    public int compteur;

    public GameObject panel_de_chargement;
    
    public int chargement;
    
    public bool chargementOn;
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player") && teleportZoneOn)
        {
            Debug.Log("contact");
            /*CharacterController controller = other.GetComponent<CharacterController>();
            controller.enabled = false;
            other.transform.position = teleportZone.transform.position;
            controller.enabled = true;
            */
            Vector3 hauteur = new Vector3(0, 0, 0);
            other.transform.root.position = teleportZone.transform.position + hauteur;
            TeleportZone teleportZoneScript = teleportZone.GetComponent<TeleportZone>();
            Debug.Log("Teleporting to: " + teleportZone.transform.position);
            teleportZoneScript.teleportZoneOn = false;
            chargementOn = true;
            panel_de_chargement.SetActive(true);
        }
    }

    void Update()
    {
        if (!teleportZoneOn)
        {
            compteur++;
            if (compteur % 700 == 0)
            {
                teleportZoneOn = true;
                compteur = 0;
            }
        }

        if (chargementOn)
        {
            chargement++;
            if (chargement % 200 == 0)
            {
                chargementOn = false;
                chargement = 0;
                panel_de_chargement.SetActive(false);
            }
        }
    }
}
