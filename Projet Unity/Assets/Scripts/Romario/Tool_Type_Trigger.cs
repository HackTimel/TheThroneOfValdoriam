using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tool_Type_Trigger : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Item_Scipt_RL item;
    public Image item_visuel;
    
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item!=null)
        {
            Tool_Type_Sys_RL.instance.Show(item.description,item.name);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tool_Type_Sys_RL.instance.Hide();
    }

    public void Click_Slot()
    {
        Inventaire_RL.instance.Open_Action(item);
    }
}
