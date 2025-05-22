using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace playermov
{
    public class PlayerMovement_solo : MonoBehaviour
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
        public bool grounded { get; private set; }

        [Header("Keybinds")]
        public KeyCode jumpKey = KeyCode.Space;
        public KeyCode sprintKey = KeyCode.LeftShift;
        public KeyCode moveForward = KeyCode.W;
        public KeyCode moveBackward = KeyCode.S;
        public KeyCode moveRight = KeyCode.D;
        public KeyCode moveLeft = KeyCode.A;
        public static KeyCode pause = KeyCode.Escape;
        public KeyCode Capa1 = KeyCode.Q;
        public KeyCode Capa2 = KeyCode.T;

        public KeyCode jump
        {
            get => jumpKey;
            set => jumpKey = value;
        }

        public KeyCode devant => moveForward;
        public KeyCode derriere => moveBackward;
        public KeyCode gauche => moveLeft;
        public KeyCode droite => moveRight;

        [Header("References")]
        public Transform orientation;

        public Rigidbody rb;
        private Vector3 moveDirection;
        public bool readyToJump = true;

        public virtual void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

            UpdateKeyBindings();
        }

        public virtual void Update()
        {
            HandleInput();
            CheckGroundStatus();
            ApplyDrag();
            ControlSpeed();
        }

        public virtual void FixedUpdate()
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
            if (moveDirection.magnitude > 0.1f)
            {
                float currentSpeed = Input.GetKey(sprintKey) ? moveSpeed * sprintMultiplier : moveSpeed;
                Vector3 targetVelocity = moveDirection.normalized * currentSpeed;
                Vector3 currentVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                Vector3 velocityChange = targetVelocity - currentVelocity;

                rb.AddForce(velocityChange, ForceMode.VelocityChange);

                Quaternion targetRotation = Quaternion.LookRotation(moveDirection.normalized, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            }
            else if (grounded)
            {
                Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                Vector3 counterForce = -horizontalVelocity * 5f;
                rb.AddForce(counterForce, ForceMode.Acceleration);
            }

            if (moveDirection.magnitude < 0.1f && grounded)
            {
                Vector3 currentVelocity = rb.velocity;
                rb.velocity = new Vector3(
                    Mathf.Lerp(currentVelocity.x, 0, Time.fixedDeltaTime * 10f),
                    currentVelocity.y,
                    Mathf.Lerp(currentVelocity.z, 0, Time.fixedDeltaTime * 10f)
                );
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
            grounded = Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, playerHeight * 0.5f + 0.3f, groundLayer);
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

        public void UpdateKeyBindings()
        {
            moveForward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("PlayerAvancer", "W"));
            moveBackward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("PlayerArriere", "S"));
            moveRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("PlayerDroite", "D"));
            moveLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("PlayerGauche", "A"));
        }
    }
}
