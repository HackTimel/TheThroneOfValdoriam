using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.Netcode;
using UnityEngine;

public class MultiCam : NetworkBehaviour
{
    public GameObject playerCam; // PlayerCam (la vraie caméra Unity)
    public CinemachineFreeLook freeLookCam; // TA caméra active maintenant

    public GameObject target; //ce qu'on veut regarder

    void Start()
    {
        if (IsOwner)
        {
            playerCam.SetActive(true);
            freeLookCam.gameObject.SetActive(true);
            freeLookCam.Priority = 20;
            freeLookCam.Follow = target.transform; // ou Orientation si plus précis
            freeLookCam.LookAt = target.transform;
        }
        else
        {
            playerCam.SetActive(false);
            freeLookCam.gameObject.SetActive(false);
        }
    }
}
