using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_decisions :Enemy_Base
{
    GameObject player;
    public override void Enter(Enemy_State msm)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("Decisions");
       
    }

    public override void Invoked(Enemy_State msm)
    {
        float distance = Vector3.Distance(player.transform.position, this.transform.position);

        if (distance > 6f) // Ajout d'une marge pour éviter les changements d'état trop fréquents
        {
            msm.change_state(msm.Attack);
        }
        else if (distance < 4.5f) // Le combat ne commence que si le joueur est bien proche
        {
            msm.change_state(msm.Combat);
        }
    }

    public override void Invoked0(Enemy_State msm)
    {
        Debug.Log("DECISIONS");
    }

 
}
