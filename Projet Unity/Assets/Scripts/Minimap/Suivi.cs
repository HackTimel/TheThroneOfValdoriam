using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suivi : MonoBehaviour
{
    public Transform parentObject;  
    public Vector3 offset; 

    void Update()
    {
       
        transform.position = parentObject.position + offset;
    }
}
