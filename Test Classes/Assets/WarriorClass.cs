using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Warrior : BaseCharacter
{
    public float warriorSpecialSpeedMultiplier = 1.2f;

    private void FixedUpdate()
    {
        base.FixedUpdate(); // Call base FixedUpdate for movement

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        // Warriors move slightly faster
        rb.AddForce(moveDirection.normalized * moveSpeed * warriorSpecialSpeedMultiplier, ForceMode.Force);

        if (Input.GetKey(jumpKey))
            Jump();
    }
}
