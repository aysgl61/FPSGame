using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGirlScream : MonoBehaviour
{
    AudioSource zombieGirlAS;

    public AudioClip screamAC;
    
    void Start()
    {
        zombieGirlAS = GetComponent<AudioSource>();
    }


    public void Scream()
    {
        zombieGirlAS.PlayOneShot(screamAC);
    }

   
}
