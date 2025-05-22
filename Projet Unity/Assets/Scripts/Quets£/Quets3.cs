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
    // Temps entre chaque spawn en secondes

    private float timer;


    void Start()
    {
        pnj = PnjGameObject.transform.childCount;
        timer = spawnInterval;
        rt = Panel.GetComponent<RectTransform>();

        // Changer la taille (largeur, hauteur)
        rt.sizeDelta = new Vector2(191, 57);
        Panel.gameObject.SetActive(false);
        if (!Quetes2.activation_Quets)
        {
            SpawnBoss();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!Quetes2.activation_Quets)
        {
            Panel.gameObject.SetActive(true);
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                SpawnBoss();
                timer = spawnInterval; // Réinitialise le timer
            }
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
}
