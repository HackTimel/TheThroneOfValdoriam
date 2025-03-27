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
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform point_de_depart;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float detectionLength0;
    [SerializeField] public Animator anim;
    [Header("Stat")]
    [SerializeField] private float detection_radius;
    [SerializeField] private bool awaiting_distance;
    [SerializeField] private float vitesse;
    [SerializeField] private float vitesse_marche;
    [SerializeField] private float combat_radius;
    [SerializeField] private bool is_Attacking;
    [SerializeField] private float attack_Delay;
    [SerializeField] private float vit_rot;
    /*if (Physics.Raycast(point_de_depart.position, orientation.forward, detectionLength0, playerMask))
      {
          Vector3 direction = player.position - transform.position;
          direction.y = 0;
          Quaternion targetRotation = Quaternion.LookRotation(direction);
          transform.rotation = targetRotation;
      }*/
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < combat_radius)
        {
            anim.SetBool("Combat",true);
            agent.speed = vitesse_marche;
            agent.SetDestination(player.position);
            
           
        }
         if (Vector3.Distance(player.position,transform.position)<detection_radius&&
            Vector3.Distance(player.position,transform.position)>combat_radius)
        {
            anim.SetBool("Combat",false);
            agent.speed = vitesse;
            agent.SetDestination(player.position);
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
        Gizmos.DrawWireSphere(transform.position, combat_radius);
    }
}
