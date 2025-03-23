using System.Collections;
using System.Collections.Generic;
using playermov;
using UnityEngine;


namespace climb0
{


    public class Climb_RL : MonoBehaviour
    {
        [Header("Reference")] 
        public LayerMask whatIsWall;
        public Rigidbody rb;
        public Animator animator;
        public Transform orientation;
        public Transform point_de_climb;
        
   
        [Header("Climbing")] public float climbSpeed;
        public float climbTimer;
        public float maxclimbTime;
        private bool isClimbing;
        public float climbForce;
        public float climbForce0;

        [Header("Wall Detection")] 
        public float detectionLength;
        public float detectionLength0;
        public float spherecastRadius;
        public float maxWallLookAngle;
        private float wallLookAngle;
        private RaycastHit frontWallHit;
        private bool isWallHit;
        void Start()
        {
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }

        public void Update()
        {
            WallDetection();
            StateMachine();
            if (isClimbing)
            {
                Climbing();
            }
            if (!isWallHit)
            {
                StopClimb0();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            
        }

        

        private void WallDetection()
        {
            // Vérifie s'il y a un mur devant avec SphereCast
            isWallHit = Physics.SphereCast(point_de_climb.position, spherecastRadius, orientation.forward, out frontWallHit, 
                detectionLength, whatIsWall);
            // Ajoute un Raycast pour une meilleure précision
            if (!isWallHit)
            {
                isWallHit = Physics.Raycast(point_de_climb.position, orientation.forward, 
                    out frontWallHit, detectionLength0, whatIsWall);
            }

            // Vérifie que l'angle avec le mur est correct
            if (isWallHit)
            {
                wallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);
                if (wallLookAngle > maxWallLookAngle)
                {
                    isWallHit = false;
                }
            }

            Debug.Log("Mur détecté : " + isWallHit);
        }



        private void StateMachine()
        {
            if (isWallHit && Input.GetKeyDown(KeyCode.E) && wallLookAngle < maxWallLookAngle)
            {
                if (isClimbing)
                {
                   
                    StopClimb();
                    
                }
                else
                {
                  
                    StartClimb();
                  
                }
            }
        }

        private void StartClimb()
        {

            isClimbing = true;
            climbTimer = 0f;
            rb.useGravity = false;
            rb.WakeUp();

            

        }

        private void Climbing()
        {
            /*climbTimer += Time.deltaTime;
            if (climbTimer >= maxclimbTime)
            {
                StopClimb();
                return;
            }*/
           
                rb.AddForce(Vector3.up * climbForce, ForceMode.Force);
                rb.AddForce(-frontWallHit.normal * 0.15f, ForceMode.Acceleration);
            

            animator.SetBool("Is_Climb", true);
            
           
        }

        private void StopClimb()
        {
            isClimbing = false;
            rb.useGravity = true;
            animator.SetBool("Is_Climb",false);
            Debug.Log("Stop Climb");

        }
        private void StopClimb0()
        {
            isClimbing = false;
            rb.useGravity = true;
            animator.SetBool("Is_Climb",false);

        }
    }
}
