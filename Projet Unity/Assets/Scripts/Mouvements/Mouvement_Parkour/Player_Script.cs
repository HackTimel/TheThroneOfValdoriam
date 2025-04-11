using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    [Header("Player Movement")] public float movement_speed = 4f;
    public MainCameraController MCC;
    public float rotationSpeed;
    public Quaternion requirerot;
    [Header("Player Animator")]
    public Animator animator;
    [Header("Player Conllison")]
    public CharacterController controller;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Player_Movement();
    }

    void Player_Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float movementAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        var movementInput = new Vector3(horizontal,0, vertical).normalized;
        var movementDirection = MCC.flatRotation * movementInput;
        if (movementAmount>0)
        {
           controller.Move(movementDirection * movement_speed * Time.deltaTime);
            requirerot = Quaternion.LookRotation(movementDirection);

        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, requirerot, 
            rotationSpeed * Time.deltaTime);
        animator.SetFloat("MovementValue",movementAmount,0.2f,Time.deltaTime);
       
    }
}
