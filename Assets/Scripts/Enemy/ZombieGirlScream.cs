using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGirlScream : MonoBehaviour
{
    AudioSource zombieGirlAS;

    public AudioClip screamAC;
    Transform target; //Ana karakterin konumunu tutuyo
    
    void Start()
    {
        zombieGirlAS = GetComponent<AudioSource>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position); //zombinin ve ana karakterin arasındaki mesafe
        if(distance < 2)
        {
            Scream();
        }

    }
    public void Scream()
    {
        zombieGirlAS.PlayOneShot(screamAC);
    }

   
}
