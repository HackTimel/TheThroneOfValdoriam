using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartClass : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject guerrier;
    public GameObject mage;
    public GameObject assassin;


    public bool selected;
    
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (!selected)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Lock()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        selected = true;
    }

    public void Guerrier()
    {
        guerrier.SetActive(true);
    }
    
    public void Mage()
    {
        mage.SetActive(true);
    }
    public void Assassin()
    {
        assassin.SetActive(true);
    }
}
