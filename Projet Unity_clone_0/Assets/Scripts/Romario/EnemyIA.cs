using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class EnemyIA : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] public Transform player;
    [SerializeField] public Transform poste;
    [SerializeField]public NavMeshAgent agent;
    [SerializeField] private Animator animator;
    [Header("Stat")]
    [SerializeField] private float detection_radius;
    [SerializeField] private bool awaiting_distance;
    [SerializeField] private float vitesse;
    [SerializeField] private float attack_radius;
    [SerializeField] private bool is_Attacking;
    [SerializeField] private float attack_Delay;
    [SerializeField] private float vit_rot;
        
    // Update is called once per frame
    void Update()
    {
       
       
      
        if (Vector3.Distance(player.position,transform.position)<detection_radius)
        {
            agent.speed = vitesse;
            if (!is_Attacking)
            {
                if (Vector3.Distance(player.position,transform.position)<attack_radius)
                {
                    StartCoroutine(attackPlayer());
                }
                else
                {
                    agent.SetDestination(player.position);
                }
            }
            
            
        }
        else
        {
            agent.SetDestination(poste.position);
        }
        animator.SetFloat("Speed",agent.velocity.magnitude);
       
    }

    IEnumerator attackPlayer()
    {
        is_Attacking = true;
        agent.isStopped = true;
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(attack_Delay);
        agent.isStopped = false;
        is_Attacking = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detection_radius);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, attack_radius);
    }
}
