using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    NavMeshAgent agent;
    Animator anim;
    Transform target; //ana karakterin pozisyonu
    public bool isDead= false;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position); //zombinin konumu ve ana karakterin konumu arasýndaki mesafeyi distance olarak tanýmladýk

        if(distance<10 && distance>2 /*&& !isDead*/)
        {
            agent.updatePosition = true; //pozisyonu güncellenecek
            agent.SetDestination(target.position);
            anim.SetBool("isRunning", true);
            anim.SetBool("Attack", false); //koþarken atak yapamasýn
        }
        else if( distance <2)
        {
            agent.updatePosition = false;
            anim.SetBool("isRunning", false);
            anim.SetBool("Attack", true);
        }
    }

    public void Hurt()
    {
        agent.enabled = false;
        anim.SetTrigger("Hit");
        StartCoroutine(Nav());
    }
    
    public void DeadAnim()
    {
       // isDead = true;
        anim.SetTrigger("Dead");
    }

    IEnumerator Nav()
    {
        yield return new WaitForSeconds(.75f);
        agent.enabled = true;
    }
}
