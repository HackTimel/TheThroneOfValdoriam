using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [Header("Vision")] public float visionRange = 10f;
    public float visionAngle = 90f;
    public LayerMask targetMask;
    [SerializeField] public GameObject Lui_meme;

    [Header("Debug")] public bool debugRays = true;

    public Transform oeil; // L'endroit d'où part la "vision" (souvent la tête)

    public void Update()
    {
        DetecterEnnemi();
    }

    public void DetecterEnnemi()
    {
        Collider[] ciblesDansZone = Physics.OverlapSphere(transform.position, visionRange, targetMask);

        foreach (Collider cible in ciblesDansZone)
        {
            Transform cibleTransform = cible.transform;
            Vector3 directionVersCible = (cibleTransform.position - transform.position).normalized;

            float angleVersCible = Vector3.Angle(transform.forward, directionVersCible);
            if (angleVersCible < visionAngle / 2f)
            {
                float distance = Vector3.Distance(transform.position, cibleTransform.position);

                if (distance <= visionRange)
                {
                    Lui_meme.SendMessage("suspect", cibleTransform); // Ennemi détecté
                }



            }

          
        }
    }
}

