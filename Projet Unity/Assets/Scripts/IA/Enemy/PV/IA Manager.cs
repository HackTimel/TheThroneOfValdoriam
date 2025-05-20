using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IAManager : MonoBehaviour
{
    /*
     public int difficulty; pour changer les valeurs des pv etc en fonction de celle ci.
     */
    [SerializeField] Image healthBar; //2.13 plus haut
    
    public float pv = 100f;
    
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (pv<=0)
        {
          Destroy(this.gameObject);  
        }
    }

    // Update is called once per frame
   
    
    public void TakeDamage(float damage)
    {
        pv -= damage;
        healthBar.fillAmount = pv / 100f;
    }

    public void Heal(float heal)
    {
        pv += heal;
        pv = Mathf.Clamp(pv, 0f, 100f);
        healthBar.fillAmount = pv / 100f;
    }
}
