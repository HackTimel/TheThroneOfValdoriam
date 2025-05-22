using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationBlendTreeController : NetworkBehaviour
{
    // Credits : iHeartGameDev :  https://www.youtube.com/watch?v=m8rGyoStfgQ&list=PLwyUzJb_FNeTQwyGujWRLqnfKpV-cj-eO&index=4
    [SerializeField] public MultiBasePlayer touche;
    [SerializeField] public float _accelaration = 0.1f;
    [SerializeField] public float _deccelaration = 0.5f;
    [SerializeField][Range(0f, 5f)] public float _maxVelocity = 1f;
    public Animator _animator;
    public float _velocity = 0.0f;
    public int _velocityHash;

    public bool avancer;
    public bool courrir;
    public bool grimper;
    public bool sauter;

    private void Awake()
    {
        _velocityHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOwner /*&& IsSpawned*/)
        {
            // handle calculations on the client
            HandleMovement();
            if (touche.grounded)
            {
                // have the server play the animations
                HandleAnimationServerRpc(_velocity);
            }
        }
    }

    public void HandleMovement()
    {
        avancer = Input.GetKey(touche.devant) || Input.GetKey(touche.gauche) || Input.GetKey(touche.droite) || Input.GetKey(touche.derriere);
        courrir = Input.GetKey(touche.sprintKey) && avancer;
        grimper = Input.GetKey(KeyCode.E);
        sauter = Input.GetKey(touche.jumpKey);
    }

    [ServerRpc]
    private void HandleAnimationServerRpc(float velocity)
    {
        //_animator.SetFloat(_velocityHash, velocity);
        _animator.SetBool("isWalking", avancer);
        _animator.SetBool("isRunning", courrir);
        _animator.SetBool("isJump", sauter);
    }
}
