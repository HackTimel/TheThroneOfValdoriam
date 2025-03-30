using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Attack : Enemy_Base
{
    GameObject player;
    [SerializeField]public Animator animator;
    

    public override void Enter(Enemy_State msm)
    {
      
        player = GameObject.FindGameObjectWithTag("Player");
        msm.text.color = Color.red;
        msm.text.text = "!";
        msm.Agent.SetDestination(player.transform.position);
        
    }

    public override void Invoked(Enemy_State msm)
    {
        msm.Agent.SetDestination(player.transform.position);
        animator.SetBool("Poursuite",true);
        Debug.Log("Attack");
        if (!msm.Agent.pathPending && msm.Agent.remainingDistance < 1.5f) // Vérifie que le chemin est bien calculé
        {
            msm.change_state(msm.Combat);
        }

 
    }

    public override void Invoked0(Enemy_State msm)
    {
        return;
    }

    public override void Sortir(Enemy_State msm)
    {
        animator.SetBool("Poursuite",false);
    }
}
