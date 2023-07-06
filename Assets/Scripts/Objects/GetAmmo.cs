using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAmmo : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;

    public GameObject activeCross;
    public GameObject pistol; //masada duran silah
    public GameObject ammoBox;
    private void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;

        //deneme yapabilmek için yaptým, sonradan sil
        if (Input.GetKeyDown(KeyCode.R))
        {
            Pistol pistolScript = pistol.GetComponent<Pistol>();
            pistolScript.carriedAmmo += 8;
            pistolScript.UpdateAmmoUI();

            if (pistolScript.carriedAmmo >= 40)
            {
                pistolScript.carriedAmmo = 40;  //40'tan fazla mermi alamasýn
            }
        } //
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

        if (Input.GetKey(KeyCode.E) && theDistance <= 2)
        {
            Pistol pistolScript = pistol.GetComponent<Pistol>();
            pistolScript.carriedAmmo += 8;
            pistolScript.UpdateAmmoUI();

            if(pistolScript.carriedAmmo >= 40)
            {
                pistolScript.carriedAmmo = 40;  //40'tan fazla mermi alamasýn
            }
            this.gameObject.GetComponent<BoxCollider>().enabled = false;

            actionKey.SetActive(false);
            activeCross.SetActive(false);


            Destroy(ammoBox);
        }
    }

    private void OnMouseExit()
    {
        actionKey.SetActive(false);
        activeCross.SetActive(false);
    }
}
