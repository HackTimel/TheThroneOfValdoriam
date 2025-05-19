using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BasePlayers : MonoBehaviour
{

    public float MaxHP = 100f;
    public float HPRegen = 2f;
    public float force = 25f;
    public float NextHP = 25f; //hp gagner quand on lvl up
    public float NextHpRegen = 0f; // montant d'hp regenerer en plus quand on lvl up
    public float NextForce = 15f; //force gagner quand on lvl up
    public float xpToLevelUp = 100f; //montant d'xp a avoir pour lvl up 
    public int Lvl = 1;
    public float Xp = 0f;
    public float passifXP = 2f; //montant gagner par seconde 
    private float xpMultiplicator = 1.5f; // ce qui va multiplier le montant d'xp a obtenir pour level up
    public float Mana = 100f;
    public float MaxMana = 100f;
    public float ManaSec = 5f;
    public float NextLvlMana = 50f; // Mana gagner quand on level up 
    [SerializeField] public Image healthBar;

    public float HP = 100f;
    [SerializeField] public PlayerManager playerManager;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


        if (playerManager.health_change)
        {
            if (playerManager.healthpriority < 100f)
            {
                TakeDamage(100f - playerManager.healthpriority);
            }

            playerManager.health_change = false;
        } //forcer l application des pv sauvegardés !!

        if (Input.GetKeyDown(KeyCode.U))
        {
            TakeDamage(20f);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Heal(20f);
        }

        if (HP <= 0) //cas de mort. (Temporaire car nocheckpoint)
        {
            SceneManager.LoadScene("Level1");
            HP = 100f;
            healthBar.fillAmount = HP / 100f;
        }

        Xp += passifXP * Time.deltaTime; // fait gagner passifXp toute les secondes actuellement 2 a modifier si besoin 
        while (Xp >= xpToLevelUp)
        {
            Xp -= xpToLevelUp;
            LevelUp();
        }


        if (Mana + ManaSec <= MaxMana)
        {
            Mana += ManaSec * Time.deltaTime;
        }
        else
        {
            Mana = MaxMana;
        }


        if (HP + HPRegen <= MaxHP)
        {
            HP += HPRegen * Time.deltaTime;
        }
        else
        {
            HP = MaxHP;
        }

    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        healthBar.fillAmount = HP / 100f;
    }

    public void Heal(float heal)
    {
        HP += heal;
        HP = Mathf.Clamp(HP, 0f, 100f);
        healthBar.fillAmount = HP / 100f;
    }



    public void getxp(float xp) //a appeler avec le montant d'xp souhaiter , peut passer plusieur lvl d'un coup
    {
        Xp += xp;
        while (Xp >= xpToLevelUp)
        {
            Xp -= xpToLevelUp;
            LevelUp();
        }
    }

    public void LevelUp()
    {
        Lvl++;
        xpToLevelUp *= xpMultiplicator; // augmente le montant d'xp pour  le prochain lvl up 
        MaxHP += NextHP;
        MaxMana += NextLvlMana;
        HPRegen += NextHpRegen;
        force += NextForce;

    }


    public void Usemana(int mana) // consome un montant donné de mana 
    {
        if (Mana - mana <= 0)
        {
            Mana = 0;
        }
        else
        {
            Mana -= mana;
        }
    }

    public void gainmana(int mana) // fait gagner un montant donné de mana 
    {
        if (Mana + mana <= MaxMana)
        {
            Mana += mana;
        }
        else
        {
            Mana = MaxMana;
        }

    }
}