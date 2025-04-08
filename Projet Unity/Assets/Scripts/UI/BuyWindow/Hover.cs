using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hover : MonoBehaviour
{
    
    
    public GameObject filtre;
    public int debug;

    /*private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            filtre.SetActive(true);
        }
        else
        {
            filtre.SetActive(false);
        }
    }
    */
    public void OnPointerEnter(PointerEventData eventData)
    {
        filtre.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        filtre.SetActive(false);
    }
}
