using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Comm_Slot : MonoBehaviour
{
    public Image item_visuel;
    public Allies2 allies0;
    public Manger_Commadement val;
    public  void Click_Slot()
    {
        Debug.Log("Click_Slot");
         val.Open_Action2(allies0);
    }
}
