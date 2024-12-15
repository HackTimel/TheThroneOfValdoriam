using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UIManager : MonoBehaviour
{
    public void SelectWarrior()
    {
        GameManager.Instance.SelectCharacter("Warrior");
    }

    public void SelectMage()
    {
        GameManager.Instance.SelectCharacter("Mage");
    }
}
