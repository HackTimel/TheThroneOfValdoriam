using Unity.Netcode;
using UnityEngine;
using StarterAssets;

public class NetworkPlayer : NetworkBehaviour
{
    public BasePlayer controller;
    public StarterAssetsInputs input;
    public GameObject cameraRoot;

    public override void OnNetworkSpawn()
    {
        bool isLocal = IsOwner;

        controller.enabled = true; // Toujours actif, mais ne fera rien si pas local (voir BasePlayer)
        input.enabled = isLocal;
        cameraRoot.SetActive(isLocal);
    }
}

