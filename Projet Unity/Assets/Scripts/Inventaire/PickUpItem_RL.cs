using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using UnityEngine;

public class PickUpItem_RL : MonoBehaviour
{
    [SerializeField]
    private float pickUpRange; // Distance de ramassage
    public Inventaire_RL inventaire;
    [SerializeField] private LayerMask layerMask0;
    [SerializeField] private GameObject texte;
    [SerializeField] private float sphereRadius = 1f; // Rayon du SphereCast

    void Update()
    {
        // Lancer un SphereCast
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, sphereRadius, transform.forward, out hit, pickUpRange, layerMask0))
        {
            Debug.Log("Tu pointes l'item : " + hit.transform.name);
            if (hit.transform.CompareTag("Item"))
            {
                texte.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (inventaire.Is_Full())
                    {
                        return;
                    }
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
        else
        {
            texte.SetActive(false);
        }
    }
}

