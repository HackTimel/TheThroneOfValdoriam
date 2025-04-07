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
    private float distanceToPlayer = 0f;

    void FixedUpdate()
    {
        distanceToPlayer = Vector3.Distance(player.position, transform.position);
    }
    void Update()
    {
        
        if (distanceToPlayer < combat_radius)
        {
            Debug.Log("cool0");
            Combat();
            agent.speed = 0;
        }
        else if (distanceToPlayer < detection_radius&&distanceToPlayer>combat_radius)
        {
           
            agent.speed = vitesse;
            agent.SetDestination(player.position);
        }

        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    public void Combat()
    {
        StartCoroutine(attackPlayer());
    }
    IEnumerator attackPlayer()
    {
        Debug.Log("cool012");
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
