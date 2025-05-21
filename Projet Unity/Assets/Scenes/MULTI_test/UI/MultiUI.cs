using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiUI : MonoBehaviour
{
    public GameObject bt1;
    public GameObject bt2;
    public GameObject bt3;
    public bool open = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu();
        }

    }

    public void Menu()
    {
        bt1.SetActive(!open);
        bt2.SetActive(!open);
        bt3.SetActive(!open);
            open = !open;
            if (open)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
    }
}
