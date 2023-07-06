using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSystem : MonoBehaviour
{

    public Animator anim;
    public AudioSource gateSound;
    void Start()
    {
        anim.GetComponent<Animator>();
        gateSound.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) //trigger'a deðdiði anda çalýþýr
    {
        if (other.tag == "Player")
        {
            anim.SetBool("Gate", true);
            gateSound.Play();
        }
    }

    private void OnTriggerExit(Collider other) //trigger'dan çýktýðý anda çalýþýr
    {
        if (other.tag == "Player")
        {
            anim.SetBool("Gate", false);
            gateSound.Play();
        }
    }
}


