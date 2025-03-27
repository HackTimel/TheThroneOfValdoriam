using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : Enemy_Base
{
    GameObject player;

    public override void Enter(Enemy_State msm)
    {
        Debug.Log("Suspicious");
        player = GameObject.FindGameObjectWithTag("Player");
        msm.text.color = Color.red;
        msm.text.text = "!!!";
        msm.Agent.SetDestination(player.transform.position);
    }

    public override void Invoked(Enemy_State msm)
    {
        msm.Agent.SetDestination(player.transform.position);
    }
}
