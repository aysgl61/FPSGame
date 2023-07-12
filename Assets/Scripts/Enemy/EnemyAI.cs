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

    public float turnSpeed; //player'a doðru dönme hýzý
    public float damage = 25f; //zombi, player'a atack yaptýðýnda player'ýn caný 25 azalacak

    public bool canAttack; //zombi, palyer'a atak yapacak durumda mý. Yani canýný 25 azalatabilecek mi.
    [SerializeField]
    float attackTimer = 2f; // player'ýn 2 saniyede bir caný azalsýn.
    void Start()
    {
        canAttack = true;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position); //zombinin konumu ve ana karakterin konumu arasýndaki mesafeyi distance olarak tanýmladýk

        if (distance < 10 && distance > agent.stoppingDistance && !isDead)
        {
            ChasePlayer();
        }
        else if (distance <= agent.stoppingDistance && canAttack == true && PlayerHealth.PH.isDead== false) //player canlý ise, zombi ona saldýrabilsin
        {
            agent.updateRotation = false;
            Vector3 direction = target.position - transform.position;  //zombi atak yaparken yüzünün player'a dönük olmasý için rotasyonunu ayarladýk
            direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
            agent.updatePosition = false; //durarak atacak yapacak
            anim.SetBool("isRunning", false);
            anim.SetBool("Attack", true);
        }
        else if(distance > 10) //zombir, artýk takip etmesin
        {
            StopChase();
        }
    }

    //karakteri takip ettiren fonk
    void ChasePlayer()
    {
        agent.updateRotation = true;
        agent.updatePosition = true; //pozisyonu güncellenecek
        agent.SetDestination(target.position);
        anim.SetBool("isRunning", true);
        anim.SetBool("Attack", false); //koþarken atak yapamasýn
    }

    void AttackPlayer()
    {
        PlayerHealth.PH.Damage(damage);

        //  StartCoroutine(AttackTime());
    } 

    void StopChase()
    {
        agent.updatePosition = false;
        anim.SetBool("isRunning", false);
        anim.SetBool("Attack", false);
    }

    public void Hurt()
    {
        agent.enabled = false;
        anim.SetTrigger("Hit");
        StartCoroutine(Nav());
    }
    
    public void DeadAnim()
    {
        isDead = true;
        anim.SetTrigger("Dead");
    }

    IEnumerator Nav()
    {
        yield return new WaitForSeconds(1.5f);
        agent.enabled = true;
    }

  /*  IEnumerator AttackTime()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.5f);
        PlayerHealth.PH.Damage(damage);
        yield return new WaitForSeconds(attackTimer); //caným azaldýktan sonra hemen atak yapamasýn. 2 sn sonra tekrar atak yapabilsin.
        canAttack = true;
    }*/
}
