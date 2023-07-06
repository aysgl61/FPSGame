using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    //public AudioSource doorSound;
    public GameObject activeCross;
    public bool keyTaken;
    public GameObject key;
    public GameObject getKeyText;

    
    private void Start()
    {
        keyTaken = false;
    }
    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;

    }

    //mouse kap�n�n �zerinde durunca aktif olur
    void OnMouseOver()
    {
        if (theDistance <= 1.5f)
        {
            actionKey.SetActive(true);
           
            activeCross.SetActive(true);
        }
        else
        {
            actionKey.SetActive(false);
           
            activeCross.SetActive(false);
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (theDistance <= 1.5f)
            {
                keyTaken = true;
                this.gameObject.GetComponent<BoxCollider>().enabled = false; //kap� a��ld���nda door trigger'�n collider'�n� kapat�yoruz 
                actionKey.SetActive(false);
                getKeyText.SetActive(true);
                StartCoroutine(KeyTakenText());
                key.GetComponent<MeshRenderer>().enabled = false; //key'i al�nca g�rn�rl��� kapans�n
               // doorSound.Play();
            }
        }

    }

    //mouse kap�n�n �zerinde de�ilken pasif olsun
    void OnMouseExit()
    {
        actionKey.SetActive(false);
        
        activeCross.SetActive(false);
    }

    IEnumerator KeyTakenText()
    {
        yield return new WaitForSeconds(2f);
        getKeyText.SetActive(false);
    }
}
