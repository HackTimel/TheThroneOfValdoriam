using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class THEFINALWALL : MonoBehaviour
{
    [CanBeNull]
    public PersistentManager manager;
    void Start()
    {
        manager = FindObjectOfType<PersistentManager>();
        if (manager == null)
        {
            Debug.LogError("THEFINALWALL: There is no manager in the scene.");
        }

        if (manager.hasLoaded)
        {
            if (manager.indice_spawn == 0)
            {
                
            }
        }
    }
    
}
