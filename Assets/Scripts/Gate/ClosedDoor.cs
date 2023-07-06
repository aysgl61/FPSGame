using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoor : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public AudioSource doorSound;
    public GameObject ClosedDoorText;
    public float waitTime;

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;

    }

    //mouse kap�n�n �zerinde durunca aktif olur
    void OnMouseOver()
    {
        if (theDistance <= 2)
        {
            actionKey.SetActive(true);
            
        }
        else
        {
            actionKey.SetActive(false);
           
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (theDistance <= 2)
            {
                actionKey.SetActive(false);
                ClosedDoorText.SetActive(true);
                StartCoroutine(ClosedDoors()); //IEnumerator fonk b�yle �a�r�l�r
                doorSound.Play();
            }
        }

    }

    //mouse kap�n�n �zerinde de�ilken pasif olsun
    void OnMouseExit()
    {
        actionKey.SetActive(false);
        
    }

    IEnumerator ClosedDoors() //IEnumerator -> saya� i�levi g�r�r
    {
        yield return new WaitForSeconds(waitTime);
        ClosedDoorText.SetActive(false);
    }
}
