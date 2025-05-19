using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject uiCanvas;

    public void StartClient(){
        NetworkManager.Singleton.StartClient();
		if (uiCanvas != null)
        {
            uiCanvas.SetActive(false); // Cache le Canvas
        }
    }

    public void StartHost(){
        NetworkManager.Singleton.StartHost();
		if (uiCanvas != null)
        {
            uiCanvas.SetActive(false); // Cache le Canvas
        }
    }
}