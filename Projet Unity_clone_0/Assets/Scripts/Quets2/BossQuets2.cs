using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class BossQuets2 : MonoBehaviour
{
    [Header("PV")]

    [Header("References")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;

    [Header("Stats")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float detectionRadius;
    [SerializeField] private float attackRadius;
    [SerializeField] private float attackDelay;
    [SerializeField] private float patrouille_delay;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private LayerMask whatIsPlayer;

    [SerializeField] private float detente;

    [Header("Invocation")]
    [SerializeField] private GameObject mobSquelettePrefab;
    [SerializeField] private GameObject pos1;
    [SerializeField] private GameObject pos2;
    [SerializeField] private int maxInvocations = 5;
    private int currentInvocations = 0;

    [SerializeField] private List<GameObject> tour_de_rond;

    private bool hasDestination;
    private bool isAttacking;
    private bool poursuite = false;
    private bool is_poursuite = false;
    private float timeSinceLastSeen = 0f;
    private bool suspect0;
    private bool invoking = false;
    [SerializeField] public IAManager Health;
    [SerializeField] public Quets Quetes2;

    int i = 0;

    void Start()
    {
        Health = this.GetComponent<IAManager>();
    }

    void Update()
    {
       
            Poursuite();
            if (Health.pv <= 100)
            {
                Quetes2.est_mort = true;
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
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, whatIsPlayer);
        if (colliders.Length <= 0)
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

        if (player6 == null) return;

      

        if (Vector3.Distance(player6.position, transform.position) < detectionRadius)
        {
            // Le joueur est encore détecté
            timeSinceLastSeen = 0f;

            agent.speed = chaseSpeed;
            Quaternion rot = Quaternion.LookRotation(player6.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);

            if (!isAttacking)
            {
                if (Vector3.Distance(player6.position, transform.position) < attackRadius)
                {
                    StartCoroutine(AttackPlayer());
                }
            }

            if (!invoking)
            {
                StartCoroutine(invocation());
            }
        }

        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    IEnumerator AttackPlayer()
    {
        isAttacking = true;
        agent.isStopped = true;
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(attackDelay);
        if (agent.enabled)
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

    // Optionnel : méthode pour reset les invocations
    public void ResetInvocations()
    {
        currentInvocations = 0;
    }
}

