using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public bool isKeyObtained; //anahtar alýndý mý
    public GameObject key;
    void Start()
    {
        isKeyObtained = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key1")
        {
            isKeyObtained = true;
            Destroy(key);
        }
    }

}
