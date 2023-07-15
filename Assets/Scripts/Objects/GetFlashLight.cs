using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFlashLight : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject flashTakenText;
    public GameObject activeCross;
    public bool flashTaken;
    public GameObject flashLight;

    public GameObject realFlashLight;
    public GameObject flashActivision;

    private void Start()
    {
        flashTaken = false;
    }
    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;

    }

    
    void OnMouseOver()
    {
        if (theDistance <=2f)
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
            if (theDistance <= 2f)
            {
                flashTaken = true;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                actionKey.SetActive(false);
                flashTakenText.SetActive(true);
                flashActivision.SetActive(true);

                StartCoroutine(KeyTakenText());
                activeCross.SetActive(false);
                flashLight.GetComponent<MeshRenderer>().enabled = false;

                realFlashLight.SetActive(true);
                                                                 
            }
        }

    }

    
    void OnMouseExit()
    {
        actionKey.SetActive(false);

        activeCross.SetActive(false);
    }

    IEnumerator KeyTakenText()
    {
        yield return new WaitForSeconds(2f);
        flashTakenText.SetActive(false);
        yield return new WaitForSeconds(4f);
        flashActivision.SetActive(false);
    }

}
