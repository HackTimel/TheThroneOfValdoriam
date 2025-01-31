using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] public Image healthBar;

    public float pointdevie_temporaire = 100f; //temporaire car doit être affecté à la classe joueur qui sera bientot implémenté
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //test du fonctionnement de la barre
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            TakeDamage(20f);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Heal(20f);
        }

        if (pointdevie_temporaire <= 0) //cas de mort. (Temporaire car nocheckpoint)
        {
            SceneManager.LoadScene("Level1");
            pointdevie_temporaire = 100f;
            healthBar.fillAmount = pointdevie_temporaire / 100f;
        }
        
    }


    public void TakeDamage(float damage)
    {
        pointdevie_temporaire -= damage;
        healthBar.fillAmount = pointdevie_temporaire / 100f;
    }

    public void Heal(float heal)
    {
        pointdevie_temporaire += heal;
        pointdevie_temporaire = Mathf.Clamp(pointdevie_temporaire, 0f, 100f);
        healthBar.fillAmount = pointdevie_temporaire / 100f;
    }
}
