using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class IA_Allie_Comportement : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject toi;
    [SerializeField] public Manger_Commadement manager_alli;
    [SerializeField] public float IA_Speed;
    [SerializeField] public float distance;
    [SerializeField] public NavMeshAgent agent;
    [SerializeField] public Animator animator;
    [SerializeField] public Collider Allie_Collider;
    [SerializeField] public GameObject Text;
    [SerializeField] public GameObject Text0;
    [SerializeField] public Allies2 Allies_current;
    [SerializeField] public LayerMask Mask_enemies;
    public bool Is_Suivre= false;
    public Transform Objectif;
    public bool Is_Suivre0 = false;
    public bool isAttacking;
    [SerializeField] public float attackDelay;
    [SerializeField] public float detectionRadius;
    [SerializeField] public float rotationSpeed;
    [SerializeField]public float chaseSpeed;
    [SerializeField] public float attackRadius;
    public bool isAttack;
    void Start()
    {
        agent.acceleration = 999f;
        agent.angularSpeed = 720f;
        agent.stoppingDistance = 1f;
    }

    public void Update()
    {
        if (Is_Suivre)
        {
            Suivre();
        }
        if (Is_Suivre0)
        {
            deplcement();
        }

        if (isAttack)
        {
            Attack_Allie();
        }
        recrutement();
    }
    
    public void Suivre()
    {
       
        if (agent == null || animator == null)
        {
            Debug.Log("pb");
            return; // Stop ici si problème
        }
     
        Vector3 direction = player.transform.position - player.transform.forward * distance;
    
        if (Vector3.Distance(agent.transform.position, player.transform.position) > distance )
        {
            agent.speed = IA_Speed;
            agent.SetDestination(direction);
            animator.SetBool("Suivre", true);
          
        }
        if (Vector3.Distance(agent.transform.position, player.transform.position) <distance+1 )
        {
          
            animator.SetBool("Suivre", false);
        }

       
    }
    public  void ChangeLayer(GameObject obj, int newLayer)
    {
        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            ChangeLayer(child.gameObject, newLayer);
        }
    }


    public void deplcement()
    {
        if (Vector3.Distance(agent.transform.position, Objectif.position)>2f)
        {
            agent.speed = IA_Speed;
            animator.SetBool("Suivre", true);
            agent.SetDestination(Objectif.position);
            
        }
        else
        {
            animator.SetBool("Suivre", false);   
        }

        
    }

    public void recrutement()
    {
        
        (Allies2, GameObject) val = (Allies_current, toi);
        if (manager_alli.allies.Contains(val))
        {
        
            
                if (Vector3.Distance(transform.position,player.transform.position) < 5)
                {
                    Text0.SetActive(true);
                    if (Input.GetKey(KeyCode.V))
                    {
                        Text0.SetActive(false);
                        manager_alli.allies.Remove(val);
                        int layerID = LayerMask.NameToLayer("Allies");
                        ChangeLayer(toi,layerID);
                    }
                }
                else
                {
                    Text0.SetActive(false);
                }
             
        }
        else
        {
        
            if (manager_alli.colliders.Contains(Allie_Collider))
            {
             
                if (Vector3.Distance(transform.position,player.transform.position) < 5)
                {
                  
                    Text.SetActive(true);
                    if (Input.GetKey(KeyCode.R))
                    {
                        Text.SetActive(false);   
                        manager_alli.allies.Add(val);
                        int layerID = LayerMask.NameToLayer("Allies_Comm");
                        ChangeLayer(toi,layerID);
                    }
                }
                else
                {
                    Text.SetActive(false);   
                }
            }
        }
      
    }

    public void Attack_Allie()
    {
        Collider[] colliders = Physics.OverlapSphere(agent.transform.position, detectionRadius,Mask_enemies);
        if (colliders.Length >0)
        {
            foreach (var VARIABLE in colliders)
            {
                Poursuite(VARIABLE.gameObject);
            }
        }
    }
    public void Poursuite(GameObject obj)
    {
        
        float distance = Vector3.Distance(obj.transform.position, transform.position);

        if (distance < detectionRadius)
        {
            Vector3 direction = (obj.transform.position - transform.position).normalized;

            // Rotation fluide
            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
            }

            // Si trop proche, attaquer
            if (distance <= attackRadius )
            {
                animator.SetBool("Suivre",false);
                if (!isAttacking)
                {
                    StartCoroutine(AttackPlayer()); 
                }

  //              agent.SetDestination(transform.position);
//agent.speed = 0;
            
            }
            // Sinon suivre
            else 
            {
               
                agent.speed = chaseSpeed;
                agent.SetDestination(obj.transform.position);
                animator.SetBool("Suivre", true);
                
               
            }
        }
        
    }

    IEnumerator AttackPlayer()
    {
        isAttacking = true;
        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(attackDelay);

        isAttacking = false;
    }


}
