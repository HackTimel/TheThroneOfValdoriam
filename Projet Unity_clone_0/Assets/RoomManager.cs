using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{

    public GameObject joueur;
    [Space]
    public Transform SpawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Connexion en cours....");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("en attente du déploiement....");
        PhotonNetwork.JoinLobby();

    }

    public override void OnJoinedLobby() 
    {  
        base.OnJoinedLobby();
        PhotonNetwork.JoinOrCreateRoom("Test", null, null);
        Debug.Log("Déploiement effecté !");
        Debug.Log("Lancement de la partie en cours...");

    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("La partie commence !");
        GameObject _player = PhotonNetwork.Instantiate(joueur.name,SpawnPoint.position,Quaternion.identity);
    }
}
