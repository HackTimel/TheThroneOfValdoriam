using System.Collections;
using System.Collections.Generic;
using UnityEngine;using Cinemachine; // N'oublie pas d'importer Cinemachine
using playermov;



public class AnimationStateController : MonoBehaviour
{
    
    Animator animator;
    public FireballTargeting visée;
    public PlayerMovement_solo touche;
    private bool is_Attacking;
    public float attack_Delay;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //touche = touche.GetComponent<PlayerMovement_solo>();
    }

    // Update is called once per frame
    void Update()
    {
        // Récupérer les états des touches une seule fois
        bool avancer = Input.GetKey(touche.devant) || Input.GetKey(touche.gauche) || Input.GetKey(touche.droite) || Input.GetKey(touche.derriere);
        bool courrir = Input.GetKey(touche.sprintKey) && avancer; // Le sprint nécessite d'avancer
        bool grimper = Input.GetKey(KeyCode.E);
        bool sauter = Input.GetKey(touche.jumpKey);
        bool Capa1 = Input.GetKey(touche.Capa1);
        bool Capa2 = Input.GetKey(touche.Capa2);
        bool Attack = Input.GetKey(touche.Attack);

        // Mettre à jour les états dans l'Animator
        //if (!grimper)
        {
            animator.SetBool("isWalking", avancer);
        }
        //if (!grimper)
        {
            animator.SetBool("isRunning", courrir);
        }
        //if (!grimper)
        {
            animator.SetBool("isJump", sauter);
        }

        
            animator.SetBool("Capa1", Capa1);

            animator.SetBool("Capa2", Capa2);
            /*

            if(visée!= null)
            {
                if(visée.isTargeting)
                    animator.SetBool("Attack1", Attack);
            }
            else
            {
                animator.SetBool("Attack1", Attack);
            }
            */

            animator.SetBool("Attack1", Attack);
        
     
    }

   public void Attack_player0()
    {
        if (Input.GetMouseButtonDown(0))
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