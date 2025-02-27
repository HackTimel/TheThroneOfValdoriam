using System;
using UnityEngine;
using UnityEngine.AI;


public class EnemyIA : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] public Transform player;
    [SerializeField]public NavMeshAgent agent;
    [SerializeField] private Animator animator;
    [Header("Stat")]
    [SerializeField] private float detection_radius;
    [SerializeField] private bool awaiting_distance;
    [SerializeField] private float vitesse;
        
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position,transform.position)<detection_radius)
        {
            agent.speed = vitesse;
            agent.SetDestination(player.position);
        }
        animator.SetFloat("Speed",agent.velocity.magnitude);
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detection_radius);
    }
}
