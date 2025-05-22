using Unity.Netcode;
using UnityEngine;

public class NetworkAnimationSync : NetworkBehaviour
{
    public Animator animator;

    void Update()
    {
        if (!IsOwner) return; // chaque joueur ne pilote QUE son joueur

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        float speed = new Vector2(moveX, moveZ).magnitude;
        animator.SetFloat("Speed", speed); // ça, c’est ce que le NetworkAnimator synchronise
    }
}

