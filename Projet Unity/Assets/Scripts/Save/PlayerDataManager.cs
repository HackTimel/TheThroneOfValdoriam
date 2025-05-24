using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerDataManager : MonoBehaviour
{
    [SerializeField] public HealthManager healthManager; //pour récupérer les pv

    [SerializeField] public TMP_InputField saveNameInput;
    

    public int indice_savepoint = 0;
    
    public int indice_player = -1;

    


    public void SaveGame()
    {
        string saveName = saveNameInput.text.Trim();
        if (string.IsNullOrEmpty(saveName))
        {
            Debug.LogWarning("Nom de sauvegarde invalide !");
            saveName = "failinfoInput";
        }
        PlayerData player = new PlayerData();
        //player.position = new[] {playerTransform.position.x,playerTransform.position.y, playerTransform.position.z };
        player.health = healthManager.pointdevie_temporaire;
        player.Selected_Character = indice_player;
        player.Indice_Spawn = indice_savepoint;
        
        string json = JsonUtility.ToJson(player);
        string path = Application.persistentDataPath + "/" + $"{saveName}.json";
        File.WriteAllText(path, json);
        Debug.Log("SAUVEGARDER");
    }
}
