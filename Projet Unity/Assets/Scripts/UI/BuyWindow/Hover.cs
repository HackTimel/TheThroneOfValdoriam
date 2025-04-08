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

    private void Update() //regarde ou est la souris, 
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };
        
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
        
        bool isHovering = false;
        
        foreach (RaycastResult result in results) //compare avec les éléments d'UI
        {
            if (result.gameObject == gameObject || result.gameObject.transform.IsChildOf(transform)) //si la souris est sur notre element souhaitant être detect, alors faire :
            {
                isHovering = true;
                break;
            }
        }

        filtre.SetActive(isHovering);
    }
    
    //c'est si complexe urrrrg
    /*
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
    
   /* public void OnPointerEnter(PointerEventData eventData)
    {
        filtre.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        filtre.SetActive(false);
    }
    */
  
}
