using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour

{
    Animator animator;
    PlayerMovement touche;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        touche = GameObject.Find("Player").GetComponent<PlayerMovement>();

        
    }

    // Update is called once per frame
    void Update()
    {
        bool avancer = Input.GetKey(touche.devant) || Input.GetKey(touche.gauche) || Input.GetKey(touche.droite) || Input.GetKey(touche.derriere);
        bool isWalking = animator.GetBool("isWalking");
        bool courrir = Input.GetKey(touche.sprintKey);
        bool sauter = Input.GetKey(touche.jumpKey);

        if(!isWalking && avancer)
        {
            animator.SetBool("isWalking", true);
        }
        if(isWalking && !avancer)
        {
            animator.SetBool("isWalking", false);
        }
        if(touche.grounded)
            animator.SetBool("IsFloating",false);
        if(!touche.grounded)
            animator.SetBool("IsFloating",true);


        if(courrir && avancer)
        {
            animator.SetBool("isRunning", true);
        }
        if(!avancer || !courrir)
        {
            animator.SetBool("isRunning", false);
        }


        if(sauter)
        {
            animator.SetBool("isJump", true);
        }
        if(!sauter)
        {
            animator.SetBool("isJump", false);
        }
    }
}
