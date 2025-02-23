using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tool_Type_Trigger : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
      Tool_Type_Sys_RL.instance.Show();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tool_Type_Sys_RL.instance.Hide();
    }
}
