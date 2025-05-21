using System.Collections;
using System.Collections.Generic;
using playermov;
using Unity.Netcode;
using UnityEngine;

public class MultiBasePlayer : PlayerMovement
{
    [Header("Player Stats")]
    public string Name;
    public float Pv;
    public float Mana;
    public float MaxPv;
    public float MaxMana;
    public bool Alive;
    public float Xp;
    public int Lvl;
    public Vector3 RespawnPosition;
    public float DamageMultiplicator;
    
    

    [Header("XP System")]
    public Dictionary<int, float> XpDictionary;

    void Awake()
    {
        if (!IsOwner) return;
        
    }
    public override void OnNetworkSpawn()
    {
        
        if (IsOwner)
        {
            /*Vector3 Position = new Vector3(48,7,71);
            transform.position = Position;*/

            Vector3 pos = new Vector3(48, 8, 65); //faire spawn plus haut
            this.transform.position = pos;
        }
        

        
    }
    void Start()
    {
        if (!IsOwner) return;

        base.Start();

        Name = "Hero";
        MaxPv = 100;
        Pv = MaxPv;
        MaxMana = 50;
        Mana = MaxMana;
        Alive = true;
        DamageMultiplicator = 1;
        Lvl = 1;
        base.moveSpeed = 5;

        XpDictionary = new Dictionary<int, float>
        {
            { 1, 100 },
            { 2, 200 },
            { 3, 300 },
            { 4, 500 },
            { 5, 800 }
        };

        //RespawnPosition = transform.position;
    }

    
    public void Update()
    {
        if (!IsOwner) return;
        base.Update();

        if (!Alive)
        {
            Debug.Log($"{Name} is dead!");
        }
    }

    public  void FixedUpdate()
    {
        if (!IsOwner) return;
        base.FixedUpdate();
    }

    public void TakeDamage(float damage)
    {
        if (!Alive) return;

        Pv -= damage;
        if (Pv <= 0)
        {
            Pv = 0;
            Alive = false;
            Debug.Log($"{Name} has died!");
        }
    }

    public void Healing(float healing)
    {
        if (!Alive) return;

        Pv += healing;
        if (Pv > MaxPv) Pv = MaxPv;

        Debug.Log($"{Name} healed for {healing} points. Current HP: {Pv}");
    }

    public void Respawn()
    {
        if (!IsOwner) return;

        Alive = true;
        Pv = MaxPv;
        transform.position = RespawnPosition;

        Debug.Log($"{Name} has respawned at position {RespawnPosition}.");
    }

    public void GetXp(float xp)
    {
        if (!XpDictionary.ContainsKey(Lvl)) return;

        float levelUpXp = XpDictionary[Lvl];
        Xp += xp;

        if (Xp >= levelUpXp)
        {
            Xp -= levelUpXp;
            LevelUp();
        }

        Debug.Log($"{Name} gained {xp} XP. Current XP: {Xp}/{levelUpXp}");
    }

    public void LevelUp()
    {
        Lvl++;
        MaxPv += 10;
        MaxMana += 5;
        Pv = MaxPv;
        Mana = MaxMana;

        Debug.Log($"{Name} leveled up to Level {Lvl}!");
    }
}
