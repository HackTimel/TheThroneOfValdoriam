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
    public GameObject player;
    public PlayerDataManager dataManager;
    public HealthManager healthManager;
    


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
        player = guerrier;
        guerrier.SetActive(true);
        dataManager.indice_player = 0;
        healthManager.player = player;
    }
    
    public void Mage()
    {
        player = mage;
        mage.SetActive(true);
        dataManager.indice_player = 1;
        healthManager.player = player;
    }
    public void Assassin()
    {
        player = assassin;
        assassin.SetActive(true);
        dataManager.indice_player = 2;
        healthManager.player = player;
    }
}
