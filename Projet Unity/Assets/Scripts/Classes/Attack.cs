using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]public bool attcking = false;
    [SerializeField]public Animator animator;
    // Update is called once per frame
    void Update()
    {
        Attack0();
    }
    public void Attack0()
    {
        if (Input.GetMouseButtonDown(0)&&!attcking)
        {
            StartCoroutine(Player_Attack());
        }
    }

    IEnumerator Player_Attack()
    {
        attcking = true;
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.5f);
        attcking = false;
    }
}
