using UnityEngine;

namespace UI.BuyWindow.Call_methods
{
    public class ZoneCall : MonoBehaviour
    {
        public GameObject Windows; //la page de magasin que l'on veut afficher
        
        
        public void Start() //rendre la zone transparente
        {
           
            GetComponent<MeshRenderer>().enabled = false;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) //le joueur est entré dans la zone 
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Windows.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Windows.SetActive(false);
            }
        }
    }
}
