using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100f;
    public static PlayerHealth PH; //static oldu�u i�in di�er scriptlerde de g�z�k�r. Yani tekrardan tan�mlamam�za gerek yok PH yaz�nca bu scripte ba�lanacak.  

    public bool isDead; //player �l� m� de�il mi 
    private void Awake() //start fonkundan �nce �al���r
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
