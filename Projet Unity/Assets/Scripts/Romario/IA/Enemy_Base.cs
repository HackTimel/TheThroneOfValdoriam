using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy_Base : MonoBehaviour
{
    public abstract void Enter(Enemy_State msm);
    public abstract void Invoked(Enemy_State msm);
    public abstract void Invoked0(Enemy_State msm);
    public abstract void Sortir(Enemy_State msm);
    
}
