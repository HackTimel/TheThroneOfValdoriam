using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using UnityEngine;

public class PickUpItem_RL : MonoBehaviour
{
    [SerializeField] private float pickUpRange = 2.6f; // Distance de ramassage
    public LayerMask detectionLayer;
    public Inventaire_RL inventaire;

    void Update()
    {
       
     

        // Lancer un Raycast
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickUpRange))
        {
            Debug.Log("Tu pointes l'item : " + hit.transform.name);

            if (Input.GetKeyDown(KeyCode.E))
            {
                // Vérifier si l'objet a bien un composant Item_RL
                if (hit.transform.CompareTag("Item"))
                {
                    if (hit.transform.gameObject.GetComponent<Item_RL>().item != null)
                    {
                        inventaire.content.Add(hit.transform.gameObject.GetComponent<Item_RL>().item);
                        Destroy(hit.transform.gameObject);
                        Debug.Log("Objet ramassé : ");
                    }
                }
                else
                {
                    Debug.Log("L'objet pointé n'a pas de script Item_RL !");
                }
            }
        }
        else
        {
            Debug.Log("Aucun objet détecté.");
        }

        // Dessiner la ligne pour voir le Raycast
        Debug.DrawRay(transform.position, transform.forward* pickUpRange, Color.green);
    }
}
