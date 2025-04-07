using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barre_de_vie : MonoBehaviour
{
    public Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; // récupère la caméra principale au démarrage
    }

    void LateUpdate()
    {
        if (mainCamera != null)
        {
            // regarde dans la direction de la caméra
            transform.LookAt(transform.position + mainCamera.transform.forward);
        }
    }
}
