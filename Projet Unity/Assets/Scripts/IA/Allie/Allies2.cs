using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items",menuName = "Allies/New Allies")]
public class Allies2 : ScriptableObject
{
    public string name;
    //Nom de l'allie
    public string description;
    //Petite Description
    public Sprite visuel;
    // c'est l'image qu'on va voir dans la fenetre de commandement
    public GameObject prefab;
    //C'est le prefab de l'allie qui drop
}
