using System.Collections;
using UnityEngine;
using Unity.Netcode;
using playermov;
using Unity.Netcode.Components;

public class MultiAnimationStateController : NetworkBehaviour
{
    public Animator animator;
    public MultiBasePlayer touche;
    public float attack_Delay;
    public GameObject mage;

    private bool is_Attacking;
    private float velocity;

    public float acceleration = 0.1f;
    public float deceleration = 0.5f;
    public float maxVelocity = 1f;

    void Start()
    {
        var netAnim = mage.GetComponent<NetworkAnimator>();
        if (netAnim.Animator == animator)
        {
            Debug.Log("Animator match !");
        }

        if (!IsOwner) return;
        if (animator == null) animator = GetComponent<Animator>();
        if (touche == null) touche = GetComponent<MultiBasePlayer>();
    }

    void Update()
    {
        if (!IsOwner) return;

        bool avancer = Input.GetKey(touche.devant) || Input.GetKey(touche.gauche) || Input.GetKey(touche.droite) || Input.GetKey(touche.derriere);
        bool courrir = Input.GetKey(touche.sprintKey) && avancer;
        bool grimper = Input.GetKey(KeyCode.E);
        bool sauter = Input.GetKey(touche.jumpKey);
        bool capa1 = Input.GetKey(KeyCode.A);
        bool capa2 = Input.GetKey(KeyCode.Mouse1);
        bool basicattack = Input.GetKey(KeyCode.Mouse0);

        // BlendTree (facultatif)
        float targetVelocity = courrir ? maxVelocity : (avancer ? maxVelocity / 2f : 0f);
        velocity = Mathf.MoveTowards(velocity, targetVelocity, (targetVelocity > velocity ? acceleration : deceleration) * Time.deltaTime);
        animator.SetFloat("Velocity", velocity); // BlendTree, si tu l'utilises

        // Paramètres directs pour transitions booléennes
        if (!grimper)
        {
            animator.SetBool("isWalking", avancer);
            animator.SetBool("isRunning", courrir);
            animator.SetBool("isJump", sauter);
            animator.SetBool("Capa1", capa1);
            animator.SetBool("Capa2", capa2);
            animator.SetBool("Basic Attack", basicattack);
        }

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        is_Attacking = true;
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(attack_Delay);
        is_Attacking = false;
    }
}

