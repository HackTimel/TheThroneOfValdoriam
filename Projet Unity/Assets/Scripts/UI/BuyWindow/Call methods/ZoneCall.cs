using UnityEngine;

namespace UI.BuyWindow.Call_methods
{
    public class ZoneCall : MonoBehaviour
    {
        public GameObject Windows; //la page de magasin que l'on veut afficher
        
        
        public void Start() //rendre la zone transparente
        {
            Renderer renderer = GetComponent<Renderer>();
            Color color = renderer.material.color;
            color.a = 0f; // alpha entre 0 (invisible) et 1 (opaque)
            renderer.material.color = color;
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
