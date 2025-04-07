using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Items",menuName = "Items/New Items")]
public class Item_Scipt_RL : ScriptableObject
{
   /*C'est la base du systeme d'inventaire
   J'utilise un ScriptableObject qui peut prendre toutes le varibaes que je veux
   Le ScriptableObject Item_Scipt_RL represente un item dans l'inventaire */
   
   public string name;
   //Nom de l'item
   public string description;
   //Petite Description
   public Sprite visuel;
   // c'est l'image qu'on va voir en inventaire
   public GameObject prefab;
   //C'est le prefab de l'item qui drop
   public Item_type type;
   // C'est l'enul qui permet de dire le type de l'item
}
//L'enum qui represent les differents type d'item
public enum Item_type
{
   Consomable,
   Arme,
   Livre_de_sort,
   
   
}
