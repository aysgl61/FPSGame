using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityGate : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject actionText;
    public GameObject doorAnim;
    public AudioSource doorSound;
    public GameObject activeCross;
    GetKey key;

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
        key = FindObjectOfType<GetKey>();
    }

    //mouse kap�n�n �zerinde durunca aktif olur
    void OnMouseOver()
    {
        if (theDistance <= 2)
        {
            actionKey.SetActive(true);
            actionText.SetActive(true);
            activeCross.SetActive(true);
        }
        else
        {
            actionKey.SetActive(false);
            actionText.SetActive(false);
            activeCross.SetActive(false);
        }

        if (Input.GetKey(KeyCode.E) && key.keyTaken==true)
        {
            if (theDistance <= 2)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = false; //kap� a��ld���nda door trigger'�n collider'�n� kapat�yoruz 
                actionKey.SetActive(false);
                actionText.SetActive(false);
                doorAnim.GetComponent<Animation>().Play("SecurityGate");
              
                doorSound.Play();
            }
        }

    }

    //mouse kap�n�n �zerinde de�ilken pasif olsun
    void OnMouseExit()
    {
        actionKey.SetActive(false);
        actionText.SetActive(false);
        activeCross.SetActive(false);
    }
}
