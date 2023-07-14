using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGirlScream : MonoBehaviour
{
    AudioSource zombieGirlAS;

    public AudioClip screamAC;
    public AudioClip punchAC;
    void Start()
    {
        zombieGirlAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scream()
    {
        zombieGirlAS.PlayOneShot(screamAC);
    }

    public void Punch()
    {
        zombieGirlAS.PlayOneShot(punchAC);
    }
}
