using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur_Damage : MonoBehaviour //classe mère dont heriteront les armes A APPLIQUER A L ARME QUI TOUCHERA L ENNEMI (doit avoir Box collider + IsTrigger sur la cible et l'attaquant si on veut le traverser)
{
    public float base_damage = 25f;
    [SerializeField] public IAManager Health;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Health = other.GetComponent<IAManager>(); //alors je choppe son instance de IAManager
            if (Health != null)
            {
                Health.TakeDamage(base_damage); //et boom dégâts
            }
        }
    }
}
