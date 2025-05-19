using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vague : MonoBehaviour
{
    [SerializeField] public Quets Quetes2;

    [SerializeField] public GameObject Pere_enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Quetes2.activation_Quets)
        {
            vague_squellette();
        }
    }

    public void vague_squellette()
    {
        Pere_enemies.SetActive(true);
    }
}
