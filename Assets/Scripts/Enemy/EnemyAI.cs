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

    public float turnSpeed; //player'a do�ru d�nme h�z�
    public float damage = 25f; //zombi, player'a atack yapt���nda player'�n can� 25 azalacak

    public bool canAttack; //zombi, palyer'a atak yapacak durumda m�. Yani can�n� 25 azalatabilecek mi.
    [SerializeField]
    float attackTimer = 2f; // player'�n 2 saniyede bir can� azals�n.
    void Start()
    {
        canAttack = true;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position); //zombinin konumu ve ana karakterin konumu aras�ndaki mesafeyi distance olarak tan�mlad�k

        if (distance < 10 && distance > agent.stoppingDistance && !isDead)
        {
            ChasePlayer();
        }
        else if (distance <= agent.stoppingDistance && canAttack == true && PlayerHealth.PH.isDead== false) //player canl� ise, zombi ona sald�rabilsin
        {
            agent.updateRotation = false;
            Vector3 direction = target.position - transform.position;  //zombi atak yaparken y�z�n�n player'a d�n�k olmas� i�in rotasyonunu ayarlad�k
            direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
            agent.updatePosition = false; //durarak atacak yapacak
            anim.SetBool("isRunning", false);
            anim.SetBool("Attack", true);
        }
        else if(distance > 10) //zombir, art�k takip etmesin
        {
            StopChase();
        }
    }

    //karakteri takip ettiren fonk
    void ChasePlayer()
    {
        agent.updateRotation = true;
        agent.updatePosition = true; //pozisyonu g�ncellenecek
        agent.SetDestination(target.position);
        anim.SetBool("isRunning", true);
        anim.SetBool("Attack", false); //ko�arken atak yapamas�n
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
        yield return new WaitForSeconds(attackTimer); //can�m azald�ktan sonra hemen atak yapamas�n. 2 sn sonra tekrar atak yapabilsin.
        canAttack = true;
    }*/
}
