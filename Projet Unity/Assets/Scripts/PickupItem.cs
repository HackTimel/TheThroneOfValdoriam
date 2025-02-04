using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField]
    private float PickupRange = 2.6f;

    public Inventory inventory;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward,out hit,PickupRange))
        {
            if (hit.transform.CompareTag("Item"))
            {
                Debug.Log("IL y a un item devant nous");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    inventory.content.Add(hit.transform.gameObject.GetComponent<ItemData>());
                    Debug.Log("rammasse");
                    Destroy(hit.transform.gameObject);
                   
                }
            }
        }
    }
}
