using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [Header("Liste des personnages à instancier")]
    public GameObject[] characterPrefabs;

    [Header("Position d'apparition")]
    public Transform spawnPoint;
    private bool isCursorLocked = false;

    public void SpawnCharacter(int index)
    {
        if (index >= 0 && index < characterPrefabs.Length)
        {
            Instantiate(characterPrefabs[index], spawnPoint.position, Quaternion.identity);
            LockCursor();

        }
        else
        {
            Debug.LogWarning("Index invalide pour l'instanciation !");
        }
       
        void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isCursorLocked = true;
        }

        
        
    }
}
    
