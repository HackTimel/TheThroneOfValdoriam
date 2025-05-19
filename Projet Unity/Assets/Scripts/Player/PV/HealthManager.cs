using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] public Image healthBar;

    public float pointdevie_temporaire = 100f; //temporaire car doit être affecté à la classe joueur qui sera bientot implémenté
    [SerializeField] public PlayerManager playerManager;
    public float maxHealth = 100f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update() //test du fonctionnement de la barre
    {
        if (playerManager.health_change)
        {
            if (playerManager.healthpriority < maxHealth) //changement 100f -> maxHealth
            {
                TakeDamage(maxHealth - playerManager.healthpriority);
            }
            playerManager.health_change = false;
        } //forcer l application des pv sauvegardés !!
        /*
        
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log($"degat inflifé : {20f}");
            TakeDamage(20f);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log($"pv recu : {20f}");
            Heal(20f);
        }
        */ //n'est plus nécéssaire car les appels se font depuis les classes

        if (pointdevie_temporaire <= 0) //cas de mort. (Temporaire car nocheckpoint)
        {
            SceneManager.LoadScene("Level1");
            pointdevie_temporaire = maxHealth;
            healthBar.fillAmount = pointdevie_temporaire / maxHealth;
        }
        
        
        
    }


    public void TakeDamage(float damage)
    {
        pointdevie_temporaire -= damage;
        healthBar.fillAmount = pointdevie_temporaire / maxHealth;
    }

    public void Heal(float heal)
    {
        pointdevie_temporaire += heal;
        pointdevie_temporaire = Mathf.Clamp(pointdevie_temporaire, 0f, maxHealth);
        healthBar.fillAmount = pointdevie_temporaire / maxHealth;
    }
}
