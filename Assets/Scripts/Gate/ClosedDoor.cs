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

    //mouse kapýnýn üzerinde durunca aktif olur
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
                StartCoroutine(ClosedDoors()); //IEnumerator fonk böyle çaðrýlýr
                doorSound.Play();
            }
        }

    }

    //mouse kapýnýn üzerinde deðilken pasif olsun
    void OnMouseExit()
    {
        actionKey.SetActive(false);
        
    }

    IEnumerator ClosedDoors() //IEnumerator -> sayaç iþlevi görür
    {
        yield return new WaitForSeconds(waitTime);
        ClosedDoorText.SetActive(false);
    }
}
