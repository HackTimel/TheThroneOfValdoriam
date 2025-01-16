using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : PlayerMovement
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

    void Start()
    {
        // Initialize player stats
        Name = "Hero";
        MaxPv = 100;
        Pv = MaxPv;
        MaxMana = 50;
        Mana = MaxMana;
        Alive = true;
        DamageMultiplicator = 1;
        Lvl = 1;
        base.rb = GetComponent<Rigidbody>();
        base.rb.freezeRotation = true;

        // Use the inherited moveSpeed from PlayerMovement
        base.moveSpeed = 5;

        // Initialize XP thresholds
        XpDictionary = new Dictionary<int, float>
        {
            { 1, 100 },
            { 2, 200 },
            { 3, 300 },
            { 4, 500 },
            { 5, 800 }
        };

        // Example respawn position
        RespawnPosition = transform.position;
    }

    void Update()
    {
        // Call parent update methods (movement and other inherited logic)
        base.Update();
        base.FixedUpdate();

        // Check if the player is alive
        if (!Alive)
        {
            // Example death handling logic
            Debug.Log($"{Name} is dead!");
        }
    }

    // Method to take damage
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

    // Method to heal the player
    public void Healing(float healing)
    {
        if (!Alive) return;

        Pv += healing;
        if (Pv > MaxPv) Pv = MaxPv;

        Debug.Log($"{Name} healed for {healing} points. Current HP: {Pv}");
    }

    // Method to respawn the player
    public void Respawn()
    {
        Alive = true;
        Pv = MaxPv;
        transform.position = RespawnPosition;

        Debug.Log($"{Name} has respawned at position {RespawnPosition}.");
    }

    // Method to gain experience
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

    // Method to level up
    public void LevelUp()
    {
        Lvl++;
        MaxPv += 10;  // Example stat increase on level up
        MaxMana += 5;
        Pv = MaxPv;   // Restore health on level up
        Mana = MaxMana;

        Debug.Log($"{Name} leveled up to Level {Lvl}!");
    }
}
