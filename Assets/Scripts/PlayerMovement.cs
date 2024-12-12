using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movements")]
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float sprintMulti;

    [Header("Ground check")]

    
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    [Header("Keybinds")]
    public KeyCode jumpKey;
    public KeyCode sprintKey;
    public KeyCode devant = KeyCode.Z;
    public KeyCode derriere = KeyCode.S;
    public KeyCode droite = KeyCode.D;
    public KeyCode gauche = KeyCode.Q;

    


    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    bool readyToJump = true;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    void Update()
    {
        MyInput();
        grounded = Physics.Raycast(transform.position, Vector3.down , playerHeight * 0.5f + 0.2f, whatIsGround);
        if(grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
        SpeedControl();
    }
    
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && grounded && readyToJump)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
            

    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x,0f,rb.velocity.z);
        if(Input.GetKey(sprintKey))
        {
                if(flatVel.magnitude>moveSpeed*sprintMulti)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x,rb.velocity.y,limitedVel.z);
            }
        

        }
        else
        {
            if(flatVel.magnitude>moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x,rb.velocity.y,limitedVel.z);
            }
        }

        
    }
    
}
