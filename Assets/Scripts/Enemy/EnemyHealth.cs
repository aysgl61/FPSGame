using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;

    EnemyAI enemy;

    private void Start()
    {
        enemy = GetComponent<EnemyAI>();
    }

    private void Update()
    {
        if(enemyHealth < 0)
        {
            enemyHealth = 0; //can�n 0'�n alt�na inmesini engelledik
        }
    }

    public void ReduceHealth(float reduceHealth)  //parametre olarak can�n ne kadar azalaca��n� al�yo
    {
        enemyHealth -= reduceHealth;
       

        if (enemy.isDead == true)
        {
            enemy.Hurt();
        }

        if(enemyHealth <= 0)
        {
            enemy.DeadAnim();
            Dead();
        }
       
    }

    void Dead()
    {
        Destroy(gameObject, 10f);
    }

  
}
