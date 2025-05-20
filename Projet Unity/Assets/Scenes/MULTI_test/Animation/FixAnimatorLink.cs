using UnityEngine;
using Unity.Netcode.Components;

[ExecuteInEditMode]
public class FixAnimatorLink : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        var netAnim = GetComponent<NetworkAnimator>();
        if (netAnim != null && animator != null && netAnim.Animator != animator)
        {
            netAnim.Animator = animator;
            Debug.Log("✅ NetworkAnimator link repaired");
        }
    }
}