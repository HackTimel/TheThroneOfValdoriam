using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_combat :Enemy_Base
{
    GameObject player;
    private float rotationSpeed = 180f;
    [SerializeField]public Animator animator;
    public override void Enter(Enemy_State msm)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        msm.text.color = Color.red;
        msm.text.text = "!";
        Debug.Log("Combat");
        
    }

    public override void Invoked(Enemy_State msm)
    {
        float distance = Vector3.Distance(player.transform.position, this.transform.position);

        if (distance > 6f) 
        {
            msm.change_state(msm.Attack);
            return;
        }

        // Vérifie si l'ennemi a une ligne de vue dégagée vers le joueur
        RaycastHit hit;
        Vector3 direction = player.transform.position - transform.position;
        if (Physics.Raycast(transform.position, direction.normalized, out hit, distance))
        {
            if (hit.transform.gameObject.CompareTag("Player")) 
            {
                direction.y = 0; 

                if (direction.magnitude > 0.1f) 
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                }
            }
        }

        animator.SetTrigger("Attack");
    }
    public override void Invoked0(Enemy_State msm)
    {
        return;
    }

   
}
