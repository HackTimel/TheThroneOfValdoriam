using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Items",menuName = "Items/New Items")]
public class Item_Scipt_RL : ScriptableObject
{
   public string name;
   public string description;
   public Sprite visuel;
   public GameObject prefab;
   public Item_type type;
}

public enum Item_type
{
   Consomable,
   Arme,
   Livre_de_sort,
   
   
}
