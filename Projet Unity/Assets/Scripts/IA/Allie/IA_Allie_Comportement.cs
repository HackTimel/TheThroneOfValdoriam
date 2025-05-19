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
    public bool Is_Suivre= false;
    public Transform Objectif;
    public bool Is_Suivre0 = false;
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
            Debug.Log("Suivre0");
        }
        if (Vector3.Distance(agent.transform.position, player.transform.position) <distance+1 )
        {
            Debug.Log("Suivre1");
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
        if (Vector3.Distance(agent.transform.position, Objectif.position)>1)
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
        Debug.Log("0");
        (Allies2, GameObject) val = (Allies_current, toi);
        if (manager_alli.allies.Contains(val))
        {
            Debug.Log("ERREUR");
            
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
            Debug.Log("1");
            if (manager_alli.colliders.Contains(Allie_Collider))
            {
                Debug.Log("2");
                if (Vector3.Distance(transform.position,player.transform.position) < 5)
                {
                    Debug.Log("3");
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

}
