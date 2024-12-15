using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Mage : BaseCharacter
{
    public float magicHoverForce = 2f;

    protected override void Update()
    {
        base.Update(); // Call base Update for input, ground check, drag, and speed control

        if (Input.GetKey(KeyCode.Space) && !grounded)
        {
            Hover();
        }
    }

    private void Hover()
    {
        rb.AddForce(Vector3.up * magicHoverForce, ForceMode.Acceleration);
    }
}
