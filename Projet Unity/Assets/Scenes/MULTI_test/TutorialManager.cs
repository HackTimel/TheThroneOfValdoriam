using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    
    public GameObject playerPrefab;

    public void StartClient(){
        NetworkManager.Singleton.StartClient();
        
        NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
        {
            if (NetworkManager.Singleton.LocalClientId == id)
            {
                Debug.Log("Client connecté");
            }
        };
    }

    public void StartHost(){
        if (Camera.main != null)
            Camera.main.gameObject.SetActive(false);

        NetworkManager.Singleton.StartHost();
        
    }
}