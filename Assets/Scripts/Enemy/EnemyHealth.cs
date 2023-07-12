using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;

    EnemyAI enemy;

    public GameObject bloodEffect;
    private void Start()
    {
        enemy = GetComponent<EnemyAI>();
    }

    private void Update()
    {
        if(enemyHealth < 0)
        {
            enemyHealth = 0; //canýn 0'ýn altýna inmesini engelledik
        }
    }

    public void ReduceHealth(float reduceHealth)  //parametre olarak canýn ne kadar azalacaðýný alýyo
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
        bloodEffect.SetActive(true);
        enemy.canAttack = false; //enemy öldüðünde player'a zarar veremesin.
        Destroy(gameObject, 10f);
    }

  
}
