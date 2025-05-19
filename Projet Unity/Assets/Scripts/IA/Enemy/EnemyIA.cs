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
    


    int i = 0;
    void Update()
    {
        if (poursuite)
        {
            i++;
            Poursuite();
        }
        else if(i<1)
        {
            Garde();
        }

    }

    private bool isPatrolling = false;

    void Garde()
    {
        if (!isPatrolling&&!poursuite)
        {
            StartCoroutine(GetNewDestination());
        }
    }
    public void suspect(Transform player0)
    {
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
            agent.speed = chaseSpeed;
            Quaternion rot = Quaternion.LookRotation(player.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);

            if (!isAttacking)
            {
                Debug.Log("1");
                
                if (Vector3.Distance(player.position, transform.position) < attackRadius)
                {
                    Debug.Log("2");
                    StartCoroutine(AttackPlayer());
                }
                else
                {
                    agent.SetDestination(player.position);  // Continue à poursuivre le joueur
                }
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
        textElement.text= "???";
        textElement.color = Color.yellow;
        yield return new WaitForSeconds(detente);
        // Affichage d'un message pour le débogage
        Debug.Log("Suspect");

        // Calcul de la distance une seule fois
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si le joueur est à une certaine distance, commencer à se déplacer vers lui
        if (distanceToPlayer > attackRadius)
        {
            Debug.Log("En chemin");
            // On marche vers le joueur
            agent.speed = walkSpeed;
            agent.SetDestination(player.position);
        }
        else
        {
            Debug.Log("Arriver");
            if (Vector3.Distance(player.position, transform.position) < detectionRadius)
            {
                poursuite = true;
                is_poursuite = true;
                Debug.Log("Valeur set !");
            }
        }

        // Mettre à jour l'animation en fonction de la vitesse de l'agent
        animator.SetFloat("Speed", agent.velocity.magnitude);
        Debug.Log(distanceToPlayer);
    }


    IEnumerator GetNewDestination()
    {
        isPatrolling = true;
        textElement.text= "ZZZ";
        textElement.color = Color.white;
        foreach (var VARIABLE in tour_de_rond)
        {
            agent.SetDestination(VARIABLE.transform.position);
            agent.speed = walkSpeed;
            while (agent.pathPending || agent.remainingDistance > 0.1f)
            {
                yield return null;  // Attendre jusqu'à ce que la destination soit atteinte
            }
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
