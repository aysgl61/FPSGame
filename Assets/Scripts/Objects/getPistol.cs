using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getPistol : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;

    public GameObject activeCross;
    public GameObject pistol; //masada duran silah
    public GameObject realPistol; //karakterin elindeki silah
    public GameObject ammoPanel;
    private void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
    }

    private void OnMouseOver()
    {
        if (theDistance <= 2)
        {
            actionKey.SetActive(true);
            activeCross.SetActive(true);
        }
        else
        {
            actionKey.SetActive(false);
            activeCross.SetActive(false);
        }

        if (Input.GetKey(KeyCode.E) && theDistance<=2)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;

            actionKey.SetActive(false);
            activeCross.SetActive(false);

            realPistol.SetActive(true); //karakterin elindeki silah görünür olsun
            ammoPanel.SetActive(true);
            pistol.SetActive(false);
        }
    }

    private void OnMouseExit()
    {
        actionKey.SetActive(false);
        activeCross.SetActive(false);
    }
}
