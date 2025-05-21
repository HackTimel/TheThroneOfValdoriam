using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butondesabled : MonoBehaviour
{
    public GameObject mageButton;
    public GameObject guerrierButton;
    public GameObject voleurButton;
    public GameObject retour;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void DisableAllButtons()
    {
        Debug.Log("Boutons désactivés !");
        mageButton.SetActive(false);
        guerrierButton.SetActive(false);
        voleurButton.SetActive(false);
        retour.SetActive(false);
    }
}
