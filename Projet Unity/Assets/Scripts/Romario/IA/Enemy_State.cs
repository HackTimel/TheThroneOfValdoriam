using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;


public class Enemy_State : MonoBehaviour
{
   Enemy_Base currentstate;
   public Enemy_Idl_State Idle;
   public Enemy_suspicious Suspicious;
   public Enemy_Attack Attack;
   [HideInInspector] public Vector3 suspiciousPos;
   [HideInInspector]public TMP_Text text;
   [HideInInspector] public NavMeshAgent Agent;
   [HideInInspector]public Vector3 initPos;
   [HideInInspector] public int idle_timer;

   void Awake()
   {
      Agent = GetComponent<NavMeshAgent>();
      initPos = transform.position;
      text = transform.GetChild(0).GetComponent<TMP_Text>();
      currentstate = Idle;
      currentstate.Enter(this);
      InvokeRepeating("Invoked", 1f, 1f);
      InvokeRepeating("Invoked0", 1f, 1.2f);
   }

   public void Invoked()
   {
      currentstate.Invoked(this);
   }
   public void Invoked0()
   {
      currentstate.Invoked0(this);
   }

   public void change_state(Enemy_Base state)
   {
      currentstate = state;
      currentstate.Enter(this);
   }

   public void PlayerDetected(Vector3 pos)
   {
      idle_timer = 10;
      suspiciousPos = pos;
      if (currentstate!=Attack)
      {
         change_state(Suspicious);
      }
     
   }
}
