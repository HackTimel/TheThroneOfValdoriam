using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Détruire si on touche un mur (Layer "Wall"), le sol ou un mob (tag "Mob")
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall") ||
            collision.gameObject.CompareTag("Mob") ||
            collision.gameObject.CompareTag("Ground")) // Assure-toi que le sol a bien ce tag
        {
            Destroy(gameObject);
        }
    }
}
