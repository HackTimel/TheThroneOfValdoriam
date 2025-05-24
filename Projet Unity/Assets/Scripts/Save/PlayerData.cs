using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //public float[] position;
    public float health;
    public int Selected_Character = -1;
    public int Indice_Spawn = 0; //0 on recommence au debut, 1 on spawn a la quete2, 2 on va a la quete 3
}
