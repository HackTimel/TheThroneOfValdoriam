    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Audiosphere : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private FirstPersonMovement scr;
        [SerializeField] public float spher_taille;
        [SerializeField] public Transform Player;
        [SerializeField] private float sphereSize;  // Taille de la sphère audio
        [SerializeField] private float detectionRadius; // Rayon de détection
        private Collider[] detectedColliders;  
        void Start()
        {
            GetComponent<Renderer>().enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
             GetComponent<Renderer>().enabled = false;
            
                transform.localScale = Vector3.Lerp(transform.localScale,
                    new Vector3(spher_taille,spher_taille,spher_taille), Time.deltaTime );
            
          
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Mob"))
            {
              
                other.gameObject.SendMessage("suspect",Player);
            }
        }
        private void DetectMobsInArea()
        {
            // Détection de tous les mobs dans le rayon spécifié
            detectedColliders = Physics.OverlapSphere(transform.position, detectionRadius);
        
            foreach (var collider in detectedColliders)
            {
                if (collider.CompareTag("Mob"))
                {
                    collider.gameObject.SendMessage("suspect", Player);
                }
            }
        }
    }
