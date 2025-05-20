using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject uiCanvas;
    public GameObject playerPrefab;

    public void StartClient(){
        NetworkManager.Singleton.StartClient();
        if (uiCanvas != null)
        {
            uiCanvas.SetActive(false); // Cache le Canvas
        }
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
        if (uiCanvas != null)
        {
            uiCanvas.SetActive(false); // Cache le Canvas
        }
    }
}