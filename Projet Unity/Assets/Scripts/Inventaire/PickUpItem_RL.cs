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
        Debug.Log(colliders.Length);
        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                Debug.Log(col.gameObject.name);
            }
            texte.SetActive(true);
            foreach (var VARIABLE in colliders)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (inventaire.Is_Full())
                    {
                        return;
                    }
                    inventaire.content.Add(VARIABLE.transform.gameObject.GetComponent<Item_RL>().item);
                    Destroy(VARIABLE.transform.gameObject);
                    
                }
            }
        }
        else
        {
            texte.SetActive(false);
        }
    }
}

