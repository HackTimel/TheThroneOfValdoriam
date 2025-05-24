using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float healthpriority;
    public bool health_change = false;
    public GameObject[] spawnpoints = new GameObject[3];
    public GameObject[] character = new GameObject[3];
    public int Debug_SpawnPoint;

    public GameObject panel; //a desactiver
    

    public void Start()
    { 
        //var manager = PersistentManager.instance;
       if (PersistentManager.instance.hasLoaded) //vérifie si on charge une game
       {

           Debug_SpawnPoint = PersistentManager.instance.indice_spawn;
           // Appliquer les données sauvegardées
           //playerTransform.position = new Vector3(PersistentManager.instance.savedPosition[0], PersistentManager.instance.savedPosition[1], PersistentManager.instance.savedPosition[2]);
           /*var vector3 = playerTransform.position;
           vector3.x = PersistentManager.instance.savedPosition[0];
           vector3.y = PersistentManager.instance.savedPosition[1];
           vector3.z = PersistentManager.instance.savedPosition[2];
           playerTransform.position = vector3;
           */
           if (PersistentManager.instance.indice_spawn == 0)
           {
               PersistentManager.instance.hasLoaded = false; // Reset pour éviter de recharger en boucle et ne change pas la health priority on recommence la scène
           }
           healthpriority= PersistentManager.instance.savedHealth;
           PersistentManager.instance.hasLoaded = false; // Reset pour éviter de recharger en boucle
           health_change = true;
           
           //maintenant on s'occupe du jeu;
           Debug.Log($"character.Length = {character?.Length}, spawnpoints.Length = {spawnpoints?.Length}");

           try
           {
               if (PersistentManager.instance.indice_spawn == 1)
               {
                   
                   var pos2 = character[PersistentManager.instance.selected_character].transform.position;
                   Debug.Log($"Position appliquée au personnage : {pos2}");
                   character[PersistentManager.instance.selected_character].transform.position =
                       spawnpoints[PersistentManager.instance.indice_spawn].transform.position;
                   panel.SetActive(false);
                   Debug.Log("il est censé avoir chargé");
                   character[PersistentManager.instance.selected_character].SetActive(true);
               }

               if (PersistentManager.instance.indice_spawn == 2)
               {
                   
                   character[PersistentManager.instance.selected_character].transform.position =
                       spawnpoints[PersistentManager.instance.indice_spawn].transform.position;
                   panel.SetActive(false);
                   Debug.Log("il est censé avoir chargé");
                   character[PersistentManager.instance.selected_character].SetActive(true);
               }
           }
           catch
           {
               Debug.Log("Erreur lors du chargement de la sauvegarde");
           }
           
           var pos = character[PersistentManager.instance.selected_character].transform.position;
           Debug.Log($"Position appliquée au personnage : {pos}");

           
           
       }
    }
}
