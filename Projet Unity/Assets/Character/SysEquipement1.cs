using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public Transform backPoint; // Fixe point sur le dos
    public Transform handPoint; // Fixe point sur la main
    public GameObject weapon; // L'arme
    public bool isOnBack = true; // Détermine où est l'arme
    [SerializeField] private Animator animator;

    // Position et rotation naturelles sur le dos
    public Vector3 backPositionOffset = new Vector3(0, -0.1f, 0);
    public Vector3 backRotationOffset = new Vector3(0, 0, 90); // Rotation en degrés

    // Position et rotation naturelles dans la main
    public Vector3 handPositionOffset = new Vector3(0, 0, 0);
    public Vector3 handRotationOffset = new Vector3(0, 180, 0); // Rotation en degrés

    void Update()
    {
        // Vérifie si la touche E est appuyée
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleWeaponPosition();
        }
        
        if (Input.GetMouseButtonDown(1)&&!isOnBack&&Input.GetKey(KeyCode.LeftShift)) 
        {
            
            animator.SetTrigger("Attack");
        }
        else
        {
            animator.ResetTrigger("Attack");
        }
       
        if (Input.GetMouseButtonDown(0)&&!isOnBack) 
        {
            
            animator.SetTrigger("Sword_O");
        }
        else
        {
            animator.ResetTrigger("Sword_O");
        }
        if (Input.GetMouseButtonDown(1)&&!isOnBack) 
        {
            
            animator.SetTrigger("Sword_I");
        }
        else
        {
            animator.ResetTrigger("Sword_I");
        }
        if (Input.GetMouseButtonDown(0)&&isOnBack&&Input.GetKey(KeyCode.LeftShift)) 
        {
            
            animator.SetTrigger("AttackPied");
        }
        else
        {
            animator.ResetTrigger("AttackPied");
        }

        if (isOnBack&&Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("PunchR");
        }
        else
        {
            animator.ResetTrigger("PunchR");
        }
        if (isOnBack&&Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("PunchL");
        }
        else
        {
            animator.ResetTrigger("PunchL");
        }
    }

    void ToggleWeaponPosition()
    {
        if (isOnBack)
        {
            // Déplace l'arme sur la main
            weapon.transform.SetParent(handPoint);
            weapon.transform.localPosition = handPositionOffset;
            weapon.transform.localRotation = Quaternion.Euler(handRotationOffset);
        }
        else
        {
            // Déplace l'arme sur le dos
            weapon.transform.SetParent(backPoint);
            weapon.transform.localPosition = backPositionOffset;
            weapon.transform.localRotation = Quaternion.Euler(backRotationOffset);
        }

        // Inverse l'état
        if (isOnBack)
        {
            isOnBack = false;
        }
        else
        {
            isOnBack = true;
        }
    }

 
}