using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class EpeeDegat_Multi : NetworkBehaviour
{
    public ulong ownerId; // défini dynamiquement à l'équipement
    public float degats = 10f;
    public int delay;
    public bool hit;
    
    
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        ownerId = GetComponentInParent<NetworkObject>().OwnerClientId;
    }

    void Update()
    {
        if (hit)
        {
            delay++;
            if (delay % 50 == 0)
            {
                delay = 0;
                hit = false;
            }
        }
    }

    
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (!IsOwner) return; // seul le joueur local détecte les collisions
        
        Debug.Log($"Trigger !");

        var cibleNetObj = other.GetComponentInParent<NetworkObject>();
        if (cibleNetObj == null || cibleNetObj.OwnerClientId == ownerId) return;

        var cible = other.GetComponentInParent<MultiPlayerPlayer>();
        if (cible != null && !hit)
        {
            InfligerDegatsServerRpc(cibleNetObj.NetworkObjectId);
            hit = true;
        }
    }

    [ServerRpc]
    void InfligerDegatsServerRpc(ulong cibleId)
    {
        var cibleObj = NetworkManager.Singleton.SpawnManager.SpawnedObjects[cibleId];
        var player = cibleObj.GetComponent<MultiPlayerPlayer>();
        if (player != null)
        {
            player.TakeDamageServerRpc(degats);
        }
    }
}
