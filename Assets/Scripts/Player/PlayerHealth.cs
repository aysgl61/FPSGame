using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100f;
    public static PlayerHealth PH; //static oldu�u i�in di�er scriptlerde de g�z�k�r. Yani tekrardan tan�mlamam�za gerek yok PH yaz�nca bu scripte ba�lanacak.  

    public bool isDead; //player �l� m� de�il mi 

    public Slider healthBarSlider;
    public Text healthText;

    [Header("Damage Screen")] //Inspectro k�sm�nda Damage Screen diye bir ba�l�k att� onun alt�na da bu de�i�kenleri koydu
    public Color damageColor;
    public Image damageImage;
    bool isTakingDamage = false;

    float colorSpeed = 0.5f;
    private void Awake() //start fonkundan �nce �al���r
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

        if (isTakingDamage)
        {
            damageImage.color = damageColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear,colorSpeed*Time.deltaTime); //bir �eyin zamanla iki nokta aras�nda de�i�mesini istiyorsak Lerp veya Slerp kullaabiliriz. 
        }
        isTakingDamage = false;
    }

    public void Damage(float damage)
    {
        
       if(currentHealth > 0)
        {
            if (damage >= currentHealth)
            {
                isTakingDamage = true;
                Dead();
            }
            else
            {
                isTakingDamage = true;
                currentHealth -= damage;
                healthBarSlider.value -= damage;
                UpdateText();
            }
            
        }
    }

    public void UpdateText()
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
