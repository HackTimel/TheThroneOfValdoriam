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
    public Enemy_combat Combat;
    public Enemy_decisions Decisions;

    [HideInInspector] public Vector3 suspiciousPos;
    [HideInInspector] public TMP_Text text;
    [HideInInspector] public NavMeshAgent Agent;
    [HideInInspector] public Vector3 initPos;
    [HideInInspector] public int idle_timer;

    // Variable pour conserver la dernière position cible
    private Vector3 lastTargetPosition = Vector3.zero;

    void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        initPos = transform.position;
        text = transform.GetChild(0).GetComponent<TMP_Text>();
        currentstate = Idle;
        currentstate.Enter(this);

        InvokeRepeating("Invoked", 1f, 1f);
        InvokeRepeating("Invoked0", 1f, 2f);
    }

    public void Invoked()
    {
        currentstate.Invoked(this);
    }

    public void Invoked0()
    {
        currentstate.Invoked0(this);
    }

    // Méthode pour changer d'état
    public void change_state(Enemy_Base state)
    {
        currentstate = state;
        currentstate.Enter(this);
    }

    // Détection du joueur
    public void PlayerDetected(Vector3 pos)
    {
        idle_timer = 10;
        suspiciousPos = pos;
        if (currentstate != Attack)
        {
            change_state(Suspicious);
        }
    }

    // Méthode pour tenter de définir une nouvelle destination si elle change
    public void TrySetDestination(Vector3 targetPos)
    {
        if (Vector3.Distance(targetPos, lastTargetPosition) > 0.1f)
        {
            lastTargetPosition = targetPos;
            Agent.SetDestination(targetPos);
        }
    }
}