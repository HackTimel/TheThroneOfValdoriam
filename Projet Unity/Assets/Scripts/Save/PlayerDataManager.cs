using System.IO;
using TMPro;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    [SerializeField] public HealthManager healthManager; //pour récupérer les pv
    public Transform playerTransform;

    [SerializeField] public TMP_InputField saveNameInput; 

    
    
    public void SaveGame()
    {
        string saveName = saveNameInput.text.Trim();
        if (string.IsNullOrEmpty(saveName))
        {
            Debug.LogWarning("Nom de sauvegarde invalide !");
            saveName = "failinfoInput";
        }
        PlayerData player = new PlayerData();
        player.position = new[] {playerTransform.position.x,playerTransform.position.y, playerTransform.position.z };
        player.health = healthManager.pointdevie_temporaire;
        
        string json = JsonUtility.ToJson(player);
        string path = Application.persistentDataPath + "/" + $"{saveName}.json";
        File.WriteAllText(path, json);
        Debug.Log("SAUVEGARDER");
    }
}
