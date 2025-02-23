using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool_Type_Sys_RL : MonoBehaviour
{
    public static Tool_Type_Sys_RL instance;
    public GameObject tooltype;

    private void Awake()
    {
        instance = this;
        
    }
    public void Show()
    {
        tooltype.SetActive(true);
    }
    public void Hide()
    {
        tooltype.SetActive(false);
    }
}
