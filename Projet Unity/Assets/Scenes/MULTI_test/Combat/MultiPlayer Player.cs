using System.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class MultiPlayerPlayer : NetworkBehaviour
{
    public float maxHealth = 100f;
    public NetworkVariable<float> currentHealth = new NetworkVariable<float>(
        100f,
        NetworkVariableReadPermission.Everyone,
        NetworkVariableWritePermission.Server);

    [SerializeField] Image healthBar;

    public Transform spawnPoint;
    public GameObject model;
    public int delay;
    public bool dead;
    public GameObject Particule;
    public GameObject LightSource;
    public GameObject touché;
    public int Delay2;
    public bool hit;

    private void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint")?.transform;
        if (spawnPoint == null)
        {
            Debug.LogWarning("No Spawn Point");
        }

        // update l'UI quand la value changes
        currentHealth.OnValueChanged += (oldValue, newValue) =>
        {
            healthBar.fillAmount = newValue / maxHealth;
            HitClientRpc();
        };
    }

    [ServerRpc(RequireOwnership = false)]
    public void TakeDamageServerRpc(float damage)
    {
        if (!IsServer) return;

        currentHealth.Value -= damage;
    }

    [ServerRpc]
    public void HealServerRpc(float heal)
    {
        if (!IsServer) return;

        currentHealth.Value = Mathf.Clamp(currentHealth.Value + heal, 0f, maxHealth);
    }

    private void Update()
    {
        if (!IsServer) return; // Only server controls death/respawn logic

        if (currentHealth.Value <= 0f && !dead)
        {
            Death();
            dead = true;
        }

        if (dead)
        {
            delay++;
            if (delay % 500 == 0)
            {
                delay = 0;
                dead = false;
                Respawn();
            }
        }
        if(hit)
        {
            if (Delay2 % 200 == 0)
            {
                Delay2 = 0;
                hit = false;
                hitnoneClientRpc();
            }
        }

        
    }
    
    [ClientRpc]
    void SetModelActiveClientRpc(bool isActive)
    {
        model.SetActive(isActive);
    }

    [ClientRpc]
    void SetParticuleActiveClientRpc(bool isActive)
    {
        Particule.SetActive(isActive);
        LightSource.SetActive(isActive);
    }
    [ClientRpc]
    public void HitClientRpc()
    {
        if(hit == false)
        {
        touché.SetActive(true);
        hit = true;
        }
    }

    [ClientRpc]
    void hitnoneClientRpc()
    {
        touché.SetActive(false);
    }

    public void Death()
    {
        SetModelActiveClientRpc(false); //tout le monde voit la mort
        SetParticuleActiveClientRpc(true);

    }

    public void Respawn()
    {
        transform.position = spawnPoint.position;
        currentHealth.Value = maxHealth;
        SetModelActiveClientRpc(true); //tout le monde voit le respawn
        SetParticuleActiveClientRpc(false);
    }
}