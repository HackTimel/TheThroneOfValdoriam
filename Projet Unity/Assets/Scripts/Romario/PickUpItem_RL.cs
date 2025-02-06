using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpItem_RL : MonoBehaviour
{

    [SerializeField] private float pickUpRange = 2.6f;
    private float spherRaduis = 0.5f;
    private float detectionDist = 10f;
    public LayerMask detectionLayer;

    public Inventaire_RL inventaire;
    void Update()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position,spherRaduis,transform.forward,out hit,detectionDist,detectionLayer))
        {
           
                Debug.Log("Tu pointe l'item");
                if (Input.GetKeyDown(KeyCode.E))
                {
                   inventaire.content.Add(hit.transform.gameObject.GetComponent<Item_RL>().item);
                }
        }
    }
}
