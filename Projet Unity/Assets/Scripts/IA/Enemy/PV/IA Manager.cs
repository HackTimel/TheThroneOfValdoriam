using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class IAManager : MonoBehaviour
{
    /*
     public int difficulty; pour changer les valeurs des pv etc en fonction de celle ci.
     */
    [SerializeField] Image healthBar; //2.13 plus haut
    [SerializeField] [CanBeNull] public Quets quets;
    [SerializeField] [CanBeNull]public GameObject toi;
    [SerializeField] [CanBeNull]public Manger_Commadement manager_alli;
    [SerializeField] public Allies2 Allies_current;
    
    public float pv = 100f;
    
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (pv <= 0)
        {
            if (CompareTag("PNJ"))
            {
                Destroy(this.gameObject);
            }

            if (!CompareTag("Boss"))
            {
                if (CompareTag("Allie"))
                {
                    (Allies2, GameObject) val = (Allies_current, toi);
                    manager_alli.allies.Remove(val);
                    Destroy(toi);
                }
                else
                {
                    Destroy(this.gameObject);
                }

            }
            else
            {
                quets.est_mort = true;
            }

            ;
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
