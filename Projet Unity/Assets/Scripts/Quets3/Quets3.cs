using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quets3 : MonoBehaviour
{
    [SerializeField] public Quets Quetes2;
    public bool activation_Quets0 = false;
    [SerializeField] public Button Panel;
    [SerializeField] public Text texte;
    [SerializeField] public GameObject PnjGameObject;
    public int pnj;

    private RectTransform rt;

    // Start is called before the first frame update
    public GameObject bossPrefab; // Le prefab du boss à instancier
    public GameObject bossPrefab1;
    public GameObject bossPrefab2;
    public Transform spawnPoint;
    public Transform spawnPoint0;
    public Transform spawnPoint1;
    public Transform spawnPoint3;
    public Transform spawnPoint4;
    public Transform spawnPoint5;
    public float spawnInterval = 60f;
    public Text texteMinutes;   // À gauche
    public Text texteSecondes; 
    
    // À droite

    [Tooltip("Durée du décompte en secondes")]
    public float dureeTotale = 120f; // Exemple : 2 minutes

    private float tempsRestant;
    // Temps entre chaque spawn en secondes

    private float timer;


    void Start()
    {
        pnj = PnjGameObject.transform.childCount;
        timer = spawnInterval;
        rt = Panel.GetComponent<RectTransform>();

        // Changer la taille (largeur, hauteur)
        rt.sizeDelta = new Vector2(255, 79);
        Panel.gameObject.SetActive(false);
        if (!Quetes2.activation_Quets&&Quetes2.quets3)
        {
            SpawnBoss();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!Quetes2.activation_Quets&&Quetes2.quets3)
        {
            Panel.gameObject.SetActive(true);
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                SpawnBoss();
                timer = spawnInterval; // Réinitialise le timer
            }
            minuteur();
        }

        refresh_png();


    }

    public void refresh_png()
    {
        pnj = PnjGameObject.transform.childCount;
        texte.text = pnj.ToString();
    }


    void SpawnBoss()
    {
        if (bossPrefab != null && spawnPoint != null)
        {
            Instantiate(bossPrefab, spawnPoint.position, spawnPoint.rotation);
            Instantiate(bossPrefab1, spawnPoint0.position, spawnPoint.rotation);
            Instantiate(bossPrefab2, spawnPoint1.position, spawnPoint.rotation);
            Instantiate(bossPrefab, spawnPoint3.position, spawnPoint.rotation);
            Instantiate(bossPrefab1, spawnPoint4.position, spawnPoint.rotation);
            Instantiate(bossPrefab2, spawnPoint5.position, spawnPoint.rotation);

            Debug.Log("Boss spawné à " + Time.time + " secondes.");
        }

    }

    public void minuteur()
    {
        tempsRestant -= Time.deltaTime;
        
                if (tempsRestant <= 0)
                {
                    // Redémarrer le décompte
                    tempsRestant = dureeTotale;
                }
        
                int minutes = Mathf.FloorToInt(tempsRestant / 60);
                int secondes = Mathf.FloorToInt(tempsRestant % 60);
        
                // Affichage minutes
                if (minutes == 1)
                    texteMinutes.text = "1,";
                else
                    texteMinutes.text = minutes + ",";
        
                // Affichage secondes
                if (secondes == 1)
                    texteSecondes.text = "1";
                else
                    texteSecondes.text = secondes.ToString();
    }
    }

