using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Attack : Enemy_Base
{
    GameObject player;
    public float vitesse = 4;
    [SerializeField]public Animator animator;
    [SerializeField]public NavMeshAgent val;

    public override void Enter(Enemy_State msm)
    {
      
        player = GameObject.FindGameObjectWithTag("Player");
        msm.text.color = Color.red;
        msm.text.text = "!!!";
        msm.Agent.SetDestination(player.transform.position);
        msm.Agent.speed = vitesse;
    }

    public override void Invoked(Enemy_State msm)
    {
        Debug.Log("Attack");
 
    }

    public override void Invoked0(Enemy_State msm)
    {
        msm.Agent.SetDestination(player.transform.position);
        animator.SetBool("Poursuite",true);
    }
}
