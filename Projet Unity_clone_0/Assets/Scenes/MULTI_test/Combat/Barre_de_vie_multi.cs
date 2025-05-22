using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class Barre_de_vie_multi : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // toutes les caméras et on garde celle du client local
        Camera[] allCameras = GameObject.FindObjectsOfType<Camera>();

        foreach (Camera cam in allCameras)
        {
            var netBehaviour = cam.GetComponentInParent<NetworkBehaviour>();
            if (netBehaviour != null && netBehaviour.IsOwner)
            {
                mainCamera = cam;
                break;
            }
        }
    }

    void LateUpdate()
    {
        if (mainCamera != null)
        {
            // orienter vers la caméra du joueur local
            transform.LookAt(transform.position + mainCamera.transform.forward);
        }
    }
}
