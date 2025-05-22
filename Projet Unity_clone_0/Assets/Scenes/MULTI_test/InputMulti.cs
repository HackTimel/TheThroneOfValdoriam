using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using TMPro;
using Unity.Netcode.Transports.UTP;
public class InputHandler : MonoBehaviour
{
    public TMP_InputField inputField; // Référence à votre InputField (à assigner dans l'éditeur Unity)
    public UnityTransport transport;
    void Start()
    {
        // Ajoute un listener pour détecter quand l'utilisateur valide (appuie sur Entrée)
        inputField.onEndEdit.AddListener(HandleInput);
    }

    void HandleInput(string userInput)
    {
        Debug.Log("Texte saisi : " + userInput);
        
        // Tu peux aussi stocker la valeur dans une variable
        string valeurSaisie = userInput;
        transport.ConnectionData.Address = valeurSaisie;
    }
}