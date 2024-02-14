using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject actionText;
    public GameObject activeCross;

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;

    }

    
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

        if (Input.GetKey(KeyCode.E))
        {
            if (theDistance <= 2)
            {
                SceneManager.LoadScene(2); //2. sahneye gececek (level2)
            }
        }

    }
    //mouse kapýnýn üzerinde deðilken pasif olsun
    void OnMouseExit()
    {
        actionKey.SetActive(false);
        actionText.SetActive(false);
        activeCross.SetActive(false);
    }
}
