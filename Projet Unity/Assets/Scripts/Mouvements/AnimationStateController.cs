using System.Collections;
using System.Collections.Generic;
using UnityEngine;using Cinemachine; // N'oublie pas d'importer Cinemachine
using playermov;



public class AnimationStateController : MonoBehaviour
{
    
    Animator animator;
    BasePlayer touche;
    private bool is_Attacking;
    public float attack_Delay;
    public GameObject mage;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        touche = mage.GetComponent<BasePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Récupérer les états des touches une seule fois
        bool avancer = Input.GetKey(touche.devant) || Input.GetKey(touche.gauche) || Input.GetKey(touche.droite) || Input.GetKey(touche.derriere);
        bool courrir = Input.GetKey(touche.sprintKey) && avancer; // Le sprint nécessite d'avancer
        bool grimper = Input.GetKey(KeyCode.E);
        bool sauter = Input.GetKey(touche.jumpKey);

        // Mettre à jour les états dans l'Animator
        if (!grimper)
        {
            animator.SetBool("isWalking", avancer);
        }
        if (!grimper)
        {
            animator.SetBool("isRunning", courrir);
        }
        if (!grimper)
        {
            animator.SetBool("isJump", sauter);
        }
     
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