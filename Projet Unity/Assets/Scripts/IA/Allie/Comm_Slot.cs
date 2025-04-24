using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Comm_Slot : MonoBehaviour
{
    public Sprite item_visuel;
    public Allies2 allies0;
    public  void Click_Slot()
    {
        Manger_Commadement.instance0.Open_Action2(allies0);
    }
}
