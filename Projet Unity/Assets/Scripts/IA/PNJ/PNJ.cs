using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PNJ : MonoBehaviour
{
    [Header("PV")]
    
    
    [Header("References")]

    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private Animator animator;



    [Header("Stats")]
    

    [SerializeField]
    private float walkSpeed;

    [SerializeField]
    private float chaseSpeed;

    [SerializeField]
    private float detectionRadius;

    [SerializeField]
    private float attackRadius;

    [SerializeField]
    private float attackDelay;
    
    [SerializeField]
    private float patrouille_delay;


    [SerializeField]
    private float rotationSpeed;
    
    [SerializeField]
    private LayerMask whatIsPlayer;
      
    [SerializeField]
    private float detente;

    
  

    [SerializeField]
    List<GameObject> tour_de_rond;

    private bool hasDestination;
    private bool isAttacking;
    private bool poursuite = false;
    private bool is_poursuite = false;
    private float timeSinceLastSeen = 0f;
    [SerializeField] private float maxLostTime = 20f; // Temps avant de retourner en patrouille
    private bool suspect0;

   

    
    void Update()
    {
      

        Garde();
    



    }

    private bool isPatrolling = false;

    void Garde()
    {
        if (!isPatrolling)
        {
            StartCoroutine(GetNewDestination());
        }
    }
 


    IEnumerator GetNewDestination()
    {
        isPatrolling = true;
        foreach (var VARIABLE in tour_de_rond)
        {
            agent.SetDestination(VARIABLE.transform.position);
            agent.speed = walkSpeed;

            // Tant que le déplacement n'est pas terminé
            while (agent.pathPending || agent.remainingDistance > 0.1f)
            {
                // Met à jour l'animation à chaque frame
                animator.SetFloat("Speed", agent.velocity.magnitude);
                yield return null;
            }

            // Stop l'animation de marche quand le point est atteint
            animator.SetFloat("Speed", 0f);
            yield return new WaitForSeconds(patrouille_delay);
        }

        isPatrolling = false;
    }



   
}
