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
    private float visonAngle = 180f;
    private float visonRange = 10f;
    public float vitesse_marche = 1;
    [SerializeField]public Animator animator;
    [SerializeField]public NavMeshAgent val;
    public override void Enter(Enemy_State msm)
    {
        Debug.Log("Suspicious");
        target = GameObject.FindGameObjectWithTag("Player");
        msm.text.text = "?";
        msm.text.color = Color.yellow;
        msm.Agent.SetDestination(msm.suspiciousPos);

    }
    
  
    public override void Invoked(Enemy_State msm)
    {
        Debug.Log("Suspicious");
        msm.idle_timer--;
        if (msm.idle_timer <= 0)
        {
            msm.change_state(msm.Idle);
        }
        DetectPlayer(msm);
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
      
        if (Mathf.Abs(playerAngle)<visonAngle&&(Playerdistance<visonRange))
        {
          
            if (Physics.Raycast(msm.transform.position, playerDirection, out hit, Playerdistance))
            {
            
                if (hit.transform.gameObject.tag == "Player")                          
                {
                
                    Debug.Log("Player detecter");
                    msm.change_state(msm.Decisions);
                }
                
            }
        }
    }
    
}
