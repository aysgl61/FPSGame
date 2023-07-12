using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100f;
    public static PlayerHealth PH; //static olduðu için diðer scriptlerde de gözükür. Yani tekrardan tanýmlamamýza gerek yok PH yazýnca bu scripte baðlanacak.  

    public bool isDead; //player ölü mü deðil mi 

    public Slider healthBarSlider;
    public Text healthText;
    private void Awake() //start fonkundan önce çalýþýr
    {
        PH = this;
    }
    void Start()
    {
        isDead = false;
        currentHealth = maxHealth;
        healthBarSlider.value = maxHealth;
        healthText.text = maxHealth.ToString();
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
        
       if(currentHealth > 0)
        {
            if (damage >= currentHealth)
            {
                Dead();
            }
            else
            {
                currentHealth -= damage;
                healthBarSlider.value -= damage;
                UpdateText();
            }
        }
    }

    void UpdateText()
    {
        healthText.text = currentHealth.ToString();
    }

    void Dead()
    {
        currentHealth = 0;
        isDead = true;
        healthBarSlider.value = 0;
        UpdateText();
        Debug.Log("Dead");
    }
}
