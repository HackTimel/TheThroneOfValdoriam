using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] [CanBeNull] public Transform player;
    [SerializeField] [CanBeNull] StartClass instance;
    void Start()
    {
        player = instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        player = instance.player.transform;
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
