using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Attack : Enemy_Base
{
    GameObject player;
    public float vitesse = 4;
    [SerializeField] public Animator animator;

    public override void Enter(Enemy_State msm)
    {
        player = GameObject.FindGameObjectWithTag("Player");

        msm.text.color = Color.red;
        msm.text.text = "!!!";
        msm.Agent.isStopped = false; // 
        msm.Agent.speed = vitesse;
        // Une seule fois à l’entrée
        msm.TrySetDestination(player.transform.position);
    }

    public override void Invoked(Enemy_State msm)
    {
        Debug.Log("Attack");
        // Pas besoin de SetDestination ici si Invoked0 le gère
    }

    public override void Invoked0(Enemy_State msm)
    {
        float distance = Vector3.Distance(player.transform.position, this.transform.position);
        // Appel intelligent à SetDestination (évite surplace/à-coups)
        if (distance <= 3f) 
        {
            msm.change_state(msm.Combat);
            return;
        }
        msm.TrySetDestination(player.transform.position);
        // Animation reste inchangée
        animator.SetBool("Poursuite", true);
    }
}