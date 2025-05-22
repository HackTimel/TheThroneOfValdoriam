using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bulle_de_dialogue : MonoBehaviour
{
    public int ZoneID; //à changer dans l'inspecteur selon le cas
    public TextMeshProUGUI text;

    private string[] dialogue_humain = {"Mouais, même avec vous dans les parages, rien n'est sûr....", "Oui mon seigneur, vous voilà enfin !", "J'ai peut être oublié de fermer la porte ce matin", "Zut..." }; //cas de base pouvant changer

    public (int,int) _zoneID
    {
        get
        {
            return (ZoneID / 10, ZoneID % 10); //dizaine = catégorie, unité = zone
        } 
    } //détermine si les dialogues prédéfinies du perso sont ceux de la ville, de la foret, d'un soldat etc

    public Camera main;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = main.transform.position;
        targetPos.y = transform.position.y; 
        transform.LookAt(targetPos);
        transform.Rotate(0f, 180f, 0f);
    }

    public void GenerateDialog()
    {
        text.text = dialogue_humain[Random.Range(0, dialogue_humain.Length)]; //choisi parmi les textes de bases
    }
}
