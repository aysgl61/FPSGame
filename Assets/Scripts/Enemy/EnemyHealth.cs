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

   public void ReduceHealth(float reduceHealth)  //parametre olarak can�n ne kadar azalaca��n� al�yo
    {
        if (enemyHealth > 0)
        {
            enemyHealth -= reduceHealth;
            enemy.Hurt();
        }
       
        else
        {
            enemyHealth = 0f;
            enemy.DeadAnim();
           
        }
       
    }

  
}
