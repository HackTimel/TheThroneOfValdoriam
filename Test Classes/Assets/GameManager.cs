using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject warriorPrefab;
    public GameObject magePrefab;

    private GameObject currentCharacter;

    void Awake()
{
    if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject); // This keeps the GameManager object from being destroyed when loading new scenes
    }
    else
    {
        Destroy(gameObject);
    }
}


    public void SelectCharacter(string className, Vector3 spawnPosition = default, Quaternion spawnRotation = default)
    {
        if (currentCharacter != null) Destroy(currentCharacter);

        // Use default position if not specified
        spawnPosition = spawnPosition == default ? transform.position : spawnPosition;
        spawnRotation = spawnRotation == default ? Quaternion.identity : spawnRotation;

        switch (className)
        {
            case "Warrior":
                currentCharacter = Instantiate(warriorPrefab, spawnPosition, spawnRotation);
                break;

            case "Mage":
                currentCharacter = Instantiate(magePrefab, spawnPosition, spawnRotation);
                break;

            default:
                Debug.LogError("Invalid class name");
                break;
        }
    }
}
