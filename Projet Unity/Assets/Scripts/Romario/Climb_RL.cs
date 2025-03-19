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
   
        [Header("Climbing")] public float climbSpeed;
        public float climbTimer;
        public float maxclimbTime;
        private bool isClimbing;
        public float climbForce;

        [Header("Wall Detection")] public float detectionLength;
        public float spherecastRadius;
        public float maxWallLookAngle;
        private float wallLookAngle;
        private RaycastHit frontWallHit;
        private bool isWallHit;

        public void Update()
        {
            WallDetection();
            StateMachine();
            if (isClimbing)
            {
                Climbing();
            }
        }

        private void WallDetection()
        {
            // Décalage du point de départ vers l'arrière du joueur pour éviter qu'il commence à l'intérieur du mur
            Vector3 castOrigin = transform.position - orientation.forward * 0.5f;

            isWallHit = Physics.SphereCast(
                castOrigin, 
                spherecastRadius,
                orientation.forward,
                out frontWallHit,
                detectionLength,
                whatIsWall
            );


            wallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);
            Debug.Log("Wall Detected: " + isWallHit); 
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
            

        }

        private void Climbing()
        {
            climbTimer += Time.deltaTime;
            if (climbTimer >= maxclimbTime)
            {
                StopClimb();
                return;
            }

            rb.AddForce(Vector3.up * climbForce, ForceMode.Acceleration);
            animator.SetBool("Is_Climb", true);
            //rb.AddForce(-frontWallHit.normal * 5f, ForceMode.Force);
        }

        private void StopClimb()
        {
            isClimbing = false;
            rb.useGravity = true;
            animator.SetBool("Is_Climb",false);
      

        }
    }
}
