using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class BossVague : MonoBehaviour
{
    [Header("PV")]
    private bool invoking = false;
    
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
    public TextMeshPro textElement;

    [SerializeField]
    List<GameObject> tour_de_rond;
    [Header("Invocation")]
    [SerializeField] private GameObject mobSquelettePrefab;
    [SerializeField] private GameObject pos1;
    [SerializeField] private GameObject pos2;
    [SerializeField] private int maxInvocations = 5;
    private int currentInvocations = 0;

    private bool hasDestination;
    private bool isAttacking;
    private bool poursuite = false;
    private bool is_poursuite = false;
    private float timeSinceLastSeen = 0f;
    [SerializeField] private float maxLostTime = 20f; // Temps avant de retourner en patrouille
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
    public int IndiceMin(List<float> liste)
    {
      

        int indiceMin = 0;
        float valeurMin = liste[0];

        for (int i = 1; i < liste.Count; i++)
        {
            if (liste[i] < valeurMin)
            {
                valeurMin = liste[i];
                indiceMin = i;
            }
        }

        return indiceMin;
    }


    public Transform detection()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius,whatIsPlayer);
        if (colliders.Length<=0)
        {
            return null;
        }
        List<float> val = new List<float>();
        foreach (var VARIABLE in colliders)
        {
            float distance = Vector3.Distance(VARIABLE.transform.position, transform.position);
            val.Add(distance);
            
        }
        return colliders[IndiceMin(val)].gameObject.transform;
        
    }

    public void Poursuite()
    {
       
        Transform player6 = detection();
        if (Vector3.Distance(player6.position, transform.position) < detectionRadius)
        {
           
            // Le joueur est encore détecté
            timeSinceLastSeen = 0f;

            // Reste de ta logique actuelle…
            agent.speed = chaseSpeed;
            Quaternion rot = Quaternion.LookRotation(player6.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);
           

            if (!isAttacking)
            {
                if (Vector3.Distance(player6.position, transform.position) < attackRadius)
                {
                    StartCoroutine(AttackPlayer());
                }
                else
                {
                    agent.SetDestination(player6.position);
                    if (!invoking)
                    {
                        StartCoroutine(invocation());
                    }
                }
            }
        }
        else
        {
         
            // Le joueur n'est plus vu
            agent.updateRotation = true;
            timeSinceLastSeen += Time.deltaTime;

            if (timeSinceLastSeen > maxLostTime)
            {
                // Le joueur est perdu de vue, retour à la patrouille
                textElement.text= "ZZZ";
                textElement.color = Color.white;
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
        Transform player6 = detection();
        if (player6 == null)
        {
            // Arrête la coroutine
            yield break;
        }
        textElement.text = "???";
        textElement.color = Color.yellow;
      
        float followTime = 5f; // Durée pendant laquelle l'ennemi suit le joueur en mode suspect
        float timer = 0f;

        agent.speed = walkSpeed;

        while (timer < followTime)
        {
            if (!agent.enabled) yield break;

            float distanceToPlayer = Vector3.Distance(transform.position, player6.position);
          


            // Si le joueur est dans le rayon de détection, passe en poursuite
            if (distanceToPlayer < detectionRadius)
            {
                poursuite = true;
                is_poursuite = true;
                suspect0 = false;
                agent.updateRotation = false;
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
    IEnumerator invocation()
    {
        invoking = true;

        if (currentInvocations < maxInvocations)
        {
            Instantiate(mobSquelettePrefab, pos1.transform.position, transform.rotation);
            Instantiate(mobSquelettePrefab, pos2.transform.position, transform.rotation);
            currentInvocations += 2;
            yield return new WaitForSeconds(attackDelay);
        }

        invoking = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
