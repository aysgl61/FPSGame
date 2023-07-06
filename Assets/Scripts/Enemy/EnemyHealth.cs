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

   public void ReduceHealth(float reduceHealth)  //parametre olarak canýn ne kadar azalacaðýný alýyo
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
