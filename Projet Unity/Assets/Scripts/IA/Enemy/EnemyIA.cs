using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using TMPro;



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("PV")]
    
    
    [Header("References")]

    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private Animator animator;


    [SerializeField]
    public Transform player;
   

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
    public TextMeshPro textElement;

    [SerializeField]
    List<GameObject> tour_de_rond;

    private bool hasDestination;
    private bool isAttacking;
    private bool poursuite = false;
    private bool is_poursuite = false;
    private float timeSinceLastSeen = 0f;
    [SerializeField] private float maxLostTime = 10f; // Temps avant de retourner en patrouille
    private bool suspect0;

    


    int i = 0;
    void Update()
    {
        if (poursuite)
        {
            Poursuite();
        }

        Garde();



    }

    private bool isPatrolling = false;

    void Garde()
    {
        if (!isPatrolling&&!poursuite&&!suspect0)
        {
            StartCoroutine(GetNewDestination());
        }
    }
    public void suspect(Transform player0)
    {
        suspect0 = true;
        if (!is_poursuite)
        {
            StartCoroutine(Suspicious(player0));
        }
       
    }

    public void Poursuite()
    {
        Debug.Log("Poursuite");
        if (Vector3.Distance(player.position, transform.position) < detectionRadius)
        {
            // Le joueur est encore détecté
            timeSinceLastSeen = 0f;

            // Reste de ta logique actuelle…
            agent.speed = chaseSpeed;
            Quaternion rot = Quaternion.LookRotation(player.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);

            if (!isAttacking)
            {
                if (Vector3.Distance(player.position, transform.position) < attackRadius)
                {
                    StartCoroutine(AttackPlayer());
                }
                else
                {
                    agent.SetDestination(player.position);
                }
            }
        }
        else
        {
            textElement.text= "ZZZ";
            textElement.color = Color.white;
            // Le joueur n'est plus vu
            timeSinceLastSeen += Time.deltaTime;

            if (timeSinceLastSeen > maxLostTime)
            {
                // Le joueur est perdu de vue, retour à la patrouille
                poursuite = false;
                is_poursuite = false;
                suspect0 = false;
                timeSinceLastSeen = 0f;
                StartCoroutine(GetNewDestination());
            }
        }

        
       /*else
        {
            if (!isPatrolling)  // Reprend la patrouille si la poursuite est terminée
            {
                agent.speed = walkSpeed;
                StartCoroutine(GetNewDestination());
            }
        }*/

        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    IEnumerator Suspicious(Transform player1)
    {
        textElement.text = "???";
        textElement.color = Color.yellow;
        Debug.Log("Suspect");

        float followTime = 10f; // Durée pendant laquelle l'ennemi suit le joueur en mode suspect
        float timer = 0f;

        agent.speed = walkSpeed;

        while (timer < followTime)
        {
            if (!agent.enabled) yield break;

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
          


            // Si le joueur est dans le rayon de détection, passe en poursuite
            if (distanceToPlayer < detectionRadius)
            {
                poursuite = true;
                is_poursuite = true;
                suspect0 = false;
                yield break;
            }

            // Sinon continue à suivre le joueur en marchant
            Vector3 direction = (player1.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
            agent.SetDestination(player1.position);
            animator.SetFloat("Speed", agent.velocity.magnitude);

            timer += Time.deltaTime;
            yield return null;
        }

        // Fin du mode suspect : retour au calme ou patrouille
        textElement.text= "ZZZ";
        textElement.color = Color.white;
        poursuite = false;
        is_poursuite = false;
        suspect0 = false;
        if (!isPatrolling)
        {
            StartCoroutine(GetNewDestination());
        }
        
    }



    IEnumerator GetNewDestination()
    {
        isPatrolling = true;
        textElement.text = "ZZZ";
        textElement.color = Color.white;

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



    IEnumerator AttackPlayer()
    {
        textElement.text= "!!!";
        textElement.color = Color.red;
        isAttacking = true;
        agent.isStopped = true;
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(attackDelay);
        if(agent.enabled)
        {
            agent.isStopped = false;
        }
        isAttacking = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
