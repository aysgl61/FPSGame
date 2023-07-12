using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public GameObject paperPnael;
    public GameObject realPaper;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            paperPnael.SetActive(true);
            realPaper.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
           paperPnael.SetActive(false);
            realPaper.SetActive(true);
        }
    }
}
