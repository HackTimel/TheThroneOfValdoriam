using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class IA_Allie_Comportement : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public float IA_Speed;
    [SerializeField] public float distance;
    [SerializeField] public NavMeshAgent agent;
    [SerializeField] public Animator animator;
    public bool Is_Suivre= false;
    public Transform Objectif;
    public bool Is_Suivre0 = false;
    public void Update()
    {
        if (Is_Suivre)
        {
            Suivre();
        }
        if (Is_Suivre0)
        {
            deplcement();
        }
    }
    
    public void Suivre()
    {
       
        if (agent == null || animator == null)
        {
            Debug.Log("pb");
            return; // Stop ici si problème
        }
     
        Vector3 direction = player.transform.position - player.transform.forward * distance;
    
        if (Vector3.Distance(agent.transform.position, player.transform.position) > distance )
        {
            agent.speed = IA_Speed;
            agent.SetDestination(direction);
            animator.SetBool("Suivre", true);
            Debug.Log("Suivre0");
        }
        if (Vector3.Distance(agent.transform.position, player.transform.position) <distance+1 )
        {
            Debug.Log("Suivre1");
            animator.SetBool("Suivre", false);
        }
       
       
    }

    public void deplcement()
    {
        if (Vector3.Distance(agent.transform.position, Objectif.position)>1)
        {
            agent.speed = IA_Speed;
            animator.SetBool("Suivre", true);
            agent.SetDestination(Objectif.position);
            
        }
        else
        {
            animator.SetBool("Suivre", false);   
        }

        
    }

}
