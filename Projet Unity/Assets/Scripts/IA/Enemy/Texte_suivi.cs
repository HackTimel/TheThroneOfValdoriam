using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texte_suivi : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Vector3 offset = new Vector3(0, 2.5f, 0);

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;

            // Toujours face à la caméra
            transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
