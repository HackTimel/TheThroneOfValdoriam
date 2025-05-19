using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CapturePoint : MonoBehaviour //dans le cas ou on veut empiler les info/notif, ne pas mettre le système de notif en false;
{
    [Header("Point Data")]
    [SerializeField] int capturePointID;
    [SerializeField] string capturePointName;
    [SerializeField] private bool isplayerthere; //pour éviter de le notifier alors qu'il est la
    [Header("Notification Object")] 
    [SerializeField] GameObject notificationObject;
    [SerializeField] TextMeshProUGUI notificationText;
    [Header("Numbers")]
    public int enemy;
    public int ally;

    public int Difference
    {
        get { return ally - enemy; }
    }

    private void Update()
    {
        if (ally == 0 && enemy == 0)
        {
            return; //personne donc non contestée ?
        }
        if (Difference <= 0 && !isplayerthere)
        {
            Contested(); //pour notifier le joueur
        }
        else if (!isplayerthere)
        {
            UnContested();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //le joueur est entré dans la zone 
        {
            isplayerthere = true;
            notificationObject.SetActive(true);
            string _ally = "";
            string _enemy = "";
            if (ally <= 1)
            {
                _ally = "allié";
            }

            if (ally > 1)
            {
                _ally = "alliés";
            }

            if (enemy <= 1)
            {
                _enemy = "ennemi";
            }

            if (enemy > 1)
            {
                _enemy = "ennemis";
            }

            notificationText.text = $"{capturePointName}: {ally} " + _ally + "/" + $"{enemy} " + _enemy; //je lui indique alors dans le bandereau de notif toutes les infos
        }
        
        /* Quand on sera sur des tags

        if (other.CompareTag("ally"))
        {
            ally += 1;
        }

        if (other.CompareTag("Enemy"))
        {
            enemy += 1;
        }
        */
    }

    private void OnTriggerExit(Collider other) //plus besoin de ses infos
    {
        if (other.CompareTag("Player"))
        {
            isplayerthere = false;
            notificationText.text = "";
            notificationObject.SetActive(false);
        }
        /* quand on sera sûr des tags
        if (other.CompareTag("ally"))
        {
            ally -= 1;
        }

        if (other.CompareTag("Enemy"))
        {
            enemy -= 1;
        }
        */
    }

    public void Contested() //j'indique au joueur que ce point la est contesté !
    {
        if (notificationObject is not null)
        {
            notificationObject.SetActive(true);
            notificationText.text = $"{capturePointName} est contestée !";
        }
    }

    public void UnContested() //quand c'est plus le cas, on nettoie et on enlève l'affichage
    {
        if (notificationObject is not null)
        {
            notificationText.text = "";
            notificationObject.SetActive(false);
        }
    }
}
