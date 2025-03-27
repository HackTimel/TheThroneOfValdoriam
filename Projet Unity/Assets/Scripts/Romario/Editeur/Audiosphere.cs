using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiosphere : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private FirstPersonMovement scr;
    [SerializeField] public float spher_taille;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scr.IsRunning)
        {
            transform.localScale = Vector3.Lerp(transform.localScale,
                new Vector3(spher_taille,spher_taille,spher_taille)*2, Time.deltaTime );
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale,
                new Vector3(spher_taille,spher_taille,spher_taille), Time.deltaTime );
        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mob"))
        {
            other.gameObject.SendMessage("PlayerDetected",transform.position);
        }
    }
}
