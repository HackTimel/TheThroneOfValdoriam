using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Movement : MonoBehaviour

{
    public float walkspeed = 4f;
    public float maxvelocitychange = 10f;    // Start is called before the first frame update

    private Vector2 input;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input.Normalize();
    }


    void FixedUpdate()
    {
        rb.AddForce(CalculateMouvement(walkspeed), ForceMode.VelocityChange);
    }

    Vector3 CalculateMouvement(float vitesse)
    {
        Vector3 vitesseactuelle = new Vector3(input.x, 0, input.y);
        vitesseactuelle = transform.TransformDirection(vitesseactuelle);
        vitesseactuelle *= vitesse;

        Vector3 vélocité = rb.velocity;

        if (input.magnitude > 0.5f)
        {
            Vector3 changementvitesse = vitesseactuelle - vélocité;
            changementvitesse.x = Mathf.Clamp(changementvitesse.x, -maxvelocitychange, maxvelocitychange);
            changementvitesse.z = Mathf.Clamp(changementvitesse.z, -maxvelocitychange, maxvelocitychange);

            changementvitesse.y = 0;

            return changementvitesse;
        }
        else
        {
            return new Vector3();
        }


    }
}
