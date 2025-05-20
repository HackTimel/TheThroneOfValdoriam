using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barre_de_vie : MonoBehaviour
{
    /* a corriger pour le state text*/
    public Camera mainCamera; //la cam du prefab pour l'instant
    

    void LateUpdate()
    {
        if (mainCamera != null)
        {
            // regarde dans la direction de la caméra
            transform.LookAt(transform.position + mainCamera.transform.forward);
        }
    }
}
