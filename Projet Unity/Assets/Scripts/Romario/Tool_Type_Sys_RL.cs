using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tool_Type_Sys_RL : MonoBehaviour
{
    public static Tool_Type_Sys_RL instance;
    public Tool_Type tooltype;

    private void Awake()
    {
        instance = this;
        
    }
    public void Show(string content,string header)
    {
        tooltype.SetTexte(content,header);
        tooltype.GameObject().SetActive(true);
    }
    public void Hide()
    {
        tooltype.GameObject().SetActive(false);
    }
}
