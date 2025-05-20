using System.Collections;
using System.Collections.Generic;
using UnityEngine;using Cinemachine; // N'oublie pas d'importer Cinemachine
using playermov;
using Unity.Netcode;


public class MultiAnimationStateController : NetworkBehaviour
{
    
    public Animator animator;
    MultiBasePlayer touche;
    private bool is_Attacking;
    public float attack_Delay;
    public GameObject mage;
    

    // Start is called before the first frame update
    void Start()
    {
        if (!IsOwner) return;
        if (animator == null) animator = GetComponent<Animator>();
        if (touche == null) touche = GetComponent<MultiBasePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOwner)
        {
            // input local
            bool avancer = Input.GetKey(touche.devant) || Input.GetKey(touche.gauche) || Input.GetKey(touche.droite) || Input.GetKey(touche.derriere);
            bool courrir = Input.GetKey(touche.sprintKey) && avancer;
            bool grimper = Input.GetKey(KeyCode.E);
            bool sauter = Input.GetKey(touche.jumpKey);

            // envoyer anims réseau
            if (!grimper)
            {
                animator.SetBool("isWalking", avancer);
                animator.SetBool("isRunning", courrir);
                animator.SetBool("isJump", sauter);
            }
        }
     
    }

    public void Attack_player0()
    {
        if (IsOwner && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        is_Attacking = true;
    
     

    
        animator.SetTrigger("Attack");
    
        yield return new WaitForSeconds(attack_Delay);
    
        
       

      
        is_Attacking = false;
    }
  
    
    
}
