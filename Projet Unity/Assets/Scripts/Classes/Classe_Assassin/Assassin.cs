using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Assassin : MonoBehaviour
{
    public float MaxHP = 75f;
    public float HPRegen = 2f;
    public float NextHP = 25f; //hp gagner quand on lvl up
    public float NextHpRegen = 0f; // montant d'hp regenerer en plus quand on lvl up
    
    public float force = 25f;

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
    
    public HealthManager healthManager;

    public GameObject player; //pour le rendre invisible etc
    public bool IsInvisible = false;
    
    
    public float distanceForward; // distance à téléporter devant (augmente à chaque levelup)
    public CharacterController characterController; //si on utilise ça pour le tp
    public GameObject ParticleSystem;
    public GameObject icone_dash;
    public bool canDash = true;
    public int delay;
    


    public float HP = 100f;
    [SerializeField] public PlayerManager playerManager;

    // Update is called once per frame
    void Start()
    {
        healthManager.maxHealth = MaxHP;
        healthManager.pointdevie_temporaire = MaxHP;
        if (player == null)
        {
            Debug.LogError("Player reference is null!");
            return;
        }

        distanceForward = 20f + Lvl;
        icone_dash.SetActive(true);
    }
    
    void Update()
    {
        if (playerManager.health_change)
        {
            if (playerManager.healthpriority < 100f)
            {
                healthManager.TakeDamage(100f - playerManager.healthpriority);
            }

            playerManager.health_change = false;
        } //forcer l application des pv sauvegardés !!

        if (Input.GetKeyDown(KeyCode.U))
        {
            healthManager.TakeDamage(10f);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            healthManager.Heal(10f);
        }

        if (HP <= 0) //cas de mort. (Temporaire car nocheckpoint)
        {
            SceneManager.LoadScene("Level1");
            HP = 100f;
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

        if (Input.GetKeyDown(KeyCode.A))
        {
            Invisible();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (canDash)
            {
                Teleport_Rush();
            }
            
        }

        if (!canDash)
        {
            delay++;
            if (delay % 600 == 0)
            {
                canDash = true;
                delay = 0;
                Dash_available();
            }
        }

    }

    public void Dash_available()
    {
        Image image = icone_dash.GetComponent<Image>();
        image.color = Color.white;
    }

    public void Dash_unavailable()
    {
        Image image = icone_dash.GetComponent<Image>();
        image.color = Color.grey;
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
    
    
    /////////////////////////////////////////////////////////////////


    public void Invisible()
    {
        if (!IsInvisible)
        {
            IsInvisible = true;
            player.tag = "invisible";
           /* Renderer renderer = player.GetComponent<Renderer>();
            Color color = renderer.material.color;
            color.a = 0.4f; // alpha entre 0 (invisible) et 1 (opaque)
            renderer.material.color = color;
            */
            
        }

        if (IsInvisible)
        {
            IsInvisible = false;
            player.tag = "Player";
            /*
            Renderer renderer = player.GetComponent<Renderer>();
            Color color = renderer.material.color;
            color.a = 1f; // alpha entre 0 (invisible) et 1 (opaque)
            renderer.material.color = color;
            */
            
        }
    }

    public void Teleport_Rush()
    {
        Debug.Log("Teleporting Rush");
        Vector3 forward = player.transform.forward.normalized;
        Vector3 offset = forward * distanceForward;
        Debug.DrawRay(player.transform.position, forward * distanceForward, Color.red, 10f);

        // Calcule la direction
       

        // Désactive temporairement le CharacterController pour forcer la téléportation
        characterController.enabled = false;
        player.transform.position += offset;
        characterController.enabled = true;

        // Crée la particule à l'ancienne position (avant déplacement)
        GameObject clone = Instantiate(ParticleSystem, player.transform.position - offset, Quaternion.identity);
        clone.SetActive(true);
        clone.tag = "smoke";

        Debug.Log("Forward: " + forward + ", distance: " + distanceForward);
        Debug.Log("New Position: " + player.transform.position);
        Debug.Log("distanceForward = " + distanceForward);
        canDash = false;
        Dash_unavailable();
        
    }
    
    
}

