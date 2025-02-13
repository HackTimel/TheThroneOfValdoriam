using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    [SerializeField] public HealthManager healthManager; //pour récupérer les pv
    public Transform playerTransform;
    
    public void SaveGame(string saveName)
    {
        PlayerData player = new PlayerData();
        player.position = new float[] {playerTransform.position.x,playerTransform.position.y, playerTransform.position.z };
        player.health = healthManager.pointdevie_temporaire;
        
        string json = JsonUtility.ToJson(player);
        string path = Application.persistentDataPath + "/" + $"{saveName}.json";
        System.IO.File.WriteAllText(path, json);
    }
}
