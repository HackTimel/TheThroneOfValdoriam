using System.Collections;
using System.Collections.Generic;
using UnityEngine;using Cinemachine; // N'oublie pas d'importer Cinemachine
using playermov;



public class AnimationStateController : MonoBehaviour
{
    
    Animator animator;
    PlayerMovement touche;
    private bool is_Attacking;
    public float attack_Delay;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        touche = GameObject.Find("Mage").GetComponent<PlayerMovement>();
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

        //if(!grimper)
        {
            animator.SetBool("Capa1", Capa1);
        }
        //if(!grimper)
        {
            animator.SetBool("Capa2", Capa2);
        }
        //Attack_player0();
     
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