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

    //mouse kapýnýn üzerinde durunca aktif olur
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
                this.gameObject.GetComponent<BoxCollider>().enabled = false; //kapý açýldýðýnda door trigger'ýn collider'ýný kapatýyoruz 
                actionKey.SetActive(false);
                getKeyText.SetActive(true);
                StartCoroutine(KeyTakenText());
                key.GetComponent<MeshRenderer>().enabled = false; //key'i alýnca görnürlüðü kapansýn
               // doorSound.Play();
            }
        }

    }

    //mouse kapýnýn üzerinde deðilken pasif olsun
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
