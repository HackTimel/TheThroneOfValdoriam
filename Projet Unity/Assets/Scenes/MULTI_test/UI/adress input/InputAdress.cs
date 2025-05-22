using System.Linq;
using UnityEngine;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP; 


public class InputAdress : MonoBehaviour
{
   public GameObject startclient;
   public NetworkManager _networkManager;
   
   public void EndEdit(string input)
   {
      var transport = _networkManager.GetComponent<UnityTransport>();
      var dots = input.Count(c => c == '.');
      if (dots == 3)
      {
         startclient.SetActive(true);
         if (transport != null)
         {
            transport.ConnectionData.Address = input;
            Debug.Log("Adresse IP définie sur : " + input);
         }
      }
      else
      {
         startclient.SetActive(false);
      }
      
      
   }

}
