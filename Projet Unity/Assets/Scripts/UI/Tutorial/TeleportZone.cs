using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportZone: MonoBehaviour
{
    
    public GameObject teleportZone; // l'autre destination
    public bool teleportZoneOn;
    public int compteur;
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
            CharacterController controller = other.GetComponent<CharacterController>();
            controller.enabled = false;
            other.transform.position = teleportZone.transform.position;
            controller.enabled = true;
            //other.transform.root.position = teleportZone.transform.position;
            TeleportZone teleportZoneScript = teleportZone.GetComponent<TeleportZone>();
            teleportZoneScript.teleportZoneOn = false;
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
    }
}
