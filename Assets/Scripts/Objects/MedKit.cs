using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject activeCross;

    public GameObject medKitBox;

    PlayerHealth player;

    public GameObject fullHealthText;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
    }

    private void OnMouseOver()
    {
        if(theDistance <= 4)
        {
            if(player.currentHealth == 100)
            {
                actionKey.SetActive(false);
                activeCross.SetActive(true);
                fullHealthText.SetActive(true);
               
            }
            else if(player.currentHealth < 100)
            {
                actionKey.SetActive(true);
                activeCross.SetActive(true);
            }
           
        }
        else
        {
            actionKey.SetActive(false);
            activeCross.SetActive(false);
        }

        if (Input.GetKey(KeyCode.E))
        {
            if(theDistance <= 4)
            {
                if(player.currentHealth < 100)
                {
                    player.currentHealth += 25;
                    player.UpdateText();
                    player.healthBarSlider.value += 25;

                    actionKey.SetActive(false);
                    activeCross.SetActive(false);

                    Destroy(medKitBox);
                }
               
            }
        }
    }

    private void OnMouseExit()
    {
        actionKey.SetActive(false);
        activeCross.SetActive(false);
        fullHealthText.SetActive(false);
    }

  
}
