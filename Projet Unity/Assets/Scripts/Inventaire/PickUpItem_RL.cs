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
        Collider[] colliders = Physics.OverlapSphere(transform.position, pickUpRange, layerMask0);
        
        if (colliders.Length > 0)
        {
            texte.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                foreach (var VARIABLE in colliders)
                {
                    if (inventaire.Is_Full()) return;

                    var itemComponent = VARIABLE.transform.gameObject.GetComponent<Item_RL>();
                    if (itemComponent == null) continue;

                    inventaire.AddItem(itemComponent.item);
                    Destroy(VARIABLE.transform.gameObject);
                    break; // On ne prend qu’un objet par appui
                }
            }
        }
        else
        {
            texte.SetActive(false);
        }
    }
    
}

