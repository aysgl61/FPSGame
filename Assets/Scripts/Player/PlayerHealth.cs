using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100f;
    public static PlayerHealth PH; //static olduðu için diðer scriptlerde de gözükür. Yani tekrardan tanýmlamamýza gerek yok PH yazýnca bu scripte baðlanacak.  

    public bool isDead; //player ölü mü deðil mi 
    private void Awake() //start fonkundan önce çalýþýr
    {
        PH = this;
    }
    void Start()
    {
        isDead = false;
        currentHealth = maxHealth; 
    }

    
    void Update()
    {
        if(currentHealth <=0)
        {
            currentHealth = 0;
        }
    }

    public void Damage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            
            Dead();
        }
    }

    void Dead()
    {
        isDead = true;
        Debug.Log("Dead");
    }
}
