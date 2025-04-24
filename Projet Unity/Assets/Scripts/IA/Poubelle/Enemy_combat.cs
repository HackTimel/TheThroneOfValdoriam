using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_combat : Enemy_Base
{
    GameObject player;
    private float rotationSpeed = 120f;  // Vitesse de rotation de l'ennemi
    private float attackRange = 3f;      // Distance à laquelle l'ennemi attaque
    [SerializeField] public Animator animator;

    public override void Enter(Enemy_State msm)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        msm.text.color = Color.red;
        msm.text.text = "!!!"; // Indication pour l'état Combat
        animator.SetBool("Poursuite", false); // Arrête la poursuite si l'ennemi passe en combat
        //smsm.Agent.isStopped = true;
        Debug.Log("Combat");
    }

    public override void Invoked(Enemy_State msm)
    {
        float distance = Vector3.Distance(player.transform.position, this.transform.position);

        // Si la distance est supérieure à la portée d'attaque, change d'état pour l'attaque
        if (distance > attackRange)
        {
            msm.change_state(msm.Attack);
            return;
        }

        // Tourner vers le joueur
        RotateTowardsPlayer();

        // Vérifie la ligne de vue vers le joueur avec un Raycast
        
            animator.SetTrigger("Attack");  // Lance l'attaque si le joueur est visible
        
    }

    // Fonction pour tourner l'ennemi vers le joueur
    private void RotateTowardsPlayer()
    {
        // Calculer la direction du joueur par rapport à l'ennemi
    
        // Garder uniquement l'axe horizontal pour éviter que l'ennemi se penche
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);

            // Appliquer la rotation de façon fluide vers la direction cible
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        
    }


    public override void Invoked0(Enemy_State msm)
    {
        // No action for Invoked0 in Combat state
        return;
    }
}
