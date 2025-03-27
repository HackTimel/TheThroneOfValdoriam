using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Idl_State : Enemy_Base
{
    public override void Enter(Enemy_State msm)
    {
        Debug.Log("Idle");
        msm.text.text= "ZZZ";
        msm.text.color = Color.white;
        msm.Agent.SetDestination(msm.initPos);
    }

    public override void Invoked(Enemy_State msm)
    {
        return;
    }
}
