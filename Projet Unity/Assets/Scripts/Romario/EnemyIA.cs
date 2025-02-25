using UnityEngine;
using UnityEngine.AI;


public class EnemyIA : MonoBehaviour
{
    [Header("Reference")] [SerializeField] public Transform player;

    [SerializeField] public NavMeshAgent agent;
    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }
}
