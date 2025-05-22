using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject Input;
    
    public GameObject playerPrefab;
    private void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
        {
            if (NetworkManager.Singleton.LocalClientId == id)
            {
                Debug.Log("✅ Client connecté !");
            }
        };

        NetworkManager.Singleton.OnClientDisconnectCallback += (id) =>
        {
            if (NetworkManager.Singleton.LocalClientId == id)
            {
                Debug.LogWarning("❌ Client déconnecté !");
            }
        };
    }

    public void StartClient(){
        NetworkManager.Singleton.StartClient();
        Debug.Log("censé etre co la");
        Cursor.lockState = CursorLockMode.Locked;
        Input.SetActive(false);
    }

    public void StartHost(){
        if (Camera.main != null)
            Camera.main.gameObject.SetActive(false);
        Input.SetActive(false);
        NetworkManager.Singleton.StartHost();
        Cursor.lockState = CursorLockMode.Locked;
    }
}