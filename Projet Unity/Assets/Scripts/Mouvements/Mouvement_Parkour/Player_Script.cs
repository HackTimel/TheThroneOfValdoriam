using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    [Header("Player Movement")] public float movement_speed = 4f;
    public MainCameraController MCC;

    private void Update()
    {
        Player_Movement();
    }

    void Player_Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float movementAmount = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
        var movementInput = new Vector3(horizontal,0, vertical).normalized;
        var movementDirection = MCC.flatRotation * movementInput;
        if (movementAmount>0)
        {
            transform.position+=movementInput*movement_speed*Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(movementInput);
        }
       
    }
}
