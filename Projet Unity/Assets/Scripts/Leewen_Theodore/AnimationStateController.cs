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
        // Récupérer les états des touches une seule fois
        bool avancer = Input.GetKey(touche.devant) || Input.GetKey(touche.gauche) || Input.GetKey(touche.droite) || Input.GetKey(touche.derriere);
        bool courrir = Input.GetKey(touche.sprintKey) && avancer; // Le sprint nécessite d'avancer
        bool sauter = Input.GetKey(touche.jumpKey);

        // Mettre à jour les états dans l'Animator
        animator.SetBool("isWalking", avancer);
        animator.SetBool("isRunning", courrir);
        animator.SetBool("isJump", sauter);
    }
}