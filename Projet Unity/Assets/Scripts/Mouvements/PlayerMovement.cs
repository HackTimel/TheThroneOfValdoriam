// PlayerMovement.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float sprintMultiplier;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundLayer;
    public bool grounded { get; private set; } // Exposed for AnimationStateController

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode moveForward = KeyCode.W;
    public KeyCode moveBackward = KeyCode.S;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveLeft = KeyCode.A;
    public static KeyCode pause = KeyCode.Escape;

    public KeyCode jump
    {
        get => jumpKey;
        set => jumpKey = value;
    }

    // Re-adding old directional key references
    public KeyCode devant => moveForward;
    public KeyCode derriere => moveBackward;
    public KeyCode gauche => moveLeft;
    public KeyCode droite => moveRight;

    [Header("References")]
    public Transform orientation;

    public Rigidbody rb;
    private Vector3 moveDirection;
    private bool readyToJump = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    public void Update()
    {
        HandleInput();
        CheckGroundStatus();
        ApplyDrag();
        ControlSpeed();
    }

    public void FixedUpdate()
    {
        MovePlayer();
    }

    private void HandleInput()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.GetKey(moveForward)) verticalInput += 1f;
        if (Input.GetKey(moveBackward)) verticalInput -= 1f;
        if (Input.GetKey(moveRight)) horizontalInput += 1f;
        if (Input.GetKey(moveLeft)) horizontalInput -= 1f;

        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (Input.GetKey(jumpKey) && grounded && readyToJump)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        if (moveDirection.magnitude > 0)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
        
        Vector3 lookDirection = moveDirection.normalized;
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void CheckGroundStatus()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);
    }

    private void ApplyDrag()
    {
        rb.drag = grounded ? groundDrag : 0f;
    }

    private void ControlSpeed()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        float maxSpeed = Input.GetKey(sprintKey) ? moveSpeed * sprintMultiplier : moveSpeed;

        if (flatVelocity.magnitude > maxSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * maxSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }
}
