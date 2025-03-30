using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_suspicious : Enemy_Base
{
    private GameObject target;
    private Vector3 playerDirection;
    bool player_Detected = false;
    float Playerdistance;
    RaycastHit hit;
    private float visonAngle = 90f;
    private float visonRange = 10f;
    public float vitesse_marche = 1;
    [SerializeField]public Animator animator;
    [SerializeField]public NavMeshAgent val;
    public int rayCount = 360;
    [SerializeField] GameObject player;
    public override void Enter(Enemy_State msm)
    {
        Debug.Log("Suspicious");
        target = GameObject.FindGameObjectWithTag("Player");
        msm.text.text = "?";
        msm.text.color = Color.yellow;
        animator.SetBool("Marche",true);
        msm.Agent.SetDestination(msm.suspiciousPos);
        msm.idle_timer = 10;

    }

    private int c = 0;
  
    public override void Invoked(Enemy_State msm)
    {
        Debug.Log("Suspicious");
        if (Vector3.Distance(transform.position,msm.suspiciousPos)<1)
        {
            if (Vector3.Distance(transform.position,player.transform.position)<3)
            {
                msm.change_state(msm.Decisions);
            }
            animator.SetBool("Marche",false);
            DetectPlayer(msm);
        }
        else
        {
            msm.Agent.SetDestination(msm.suspiciousPos);
            animator.SetBool("Marche",true);
            DetectPlayer(msm);
        }
        msm.idle_timer -= Time.deltaTime; // Utilisation de Time.deltaTime pour un compte précis
        if (msm.idle_timer <= 0)
        {
            msm.change_state(msm.Idle);
        }

        
    }

    public override void Invoked0(Enemy_State msm)
    {
        return;
    }
    

    public void DetectPlayer(Enemy_State msm)
    {
        playerDirection = target.transform.position-msm.transform.position;
        Playerdistance = Vector3.Distance(target.transform.position, msm.transform.position);
        float playerAngle = Vector3.Angle(playerDirection, msm.transform.forward);
        //Debug.Log("Prime");
        if (Mathf.Abs(playerAngle)<visonAngle&&(Playerdistance<visonRange))
        {
           //Debug.Log("Seconde");
            if (Physics.Raycast(msm.transform.position, playerDirection, out hit, Playerdistance))
            {
                //Debug.Log("Tertio");
                if (hit.transform.gameObject.tag == "Player")                          
                {
                    //Debug.Log("Quadro");
                    msm.change_state(msm.Decisions);
                    return;
                }
                
            }
        }
    }
    public override void Sortir(Enemy_State msm)
    {
        animator.SetBool("Marche",false);
    }
   
   
    
}
