using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openAngle;
    public bool isLocked = false;
    bool isOpen= false;
    Quaternion startRot;
    void Start()
    {
        startRot = transform.rotation; //ba�lang�� rotasyonu
    }

    
    void Update()
    {
        Quaternion currentRot = transform.rotation;
        Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x, openAngle, transform.eulerAngles.z); //kap�y� y ekseninde d�nd�r�p a��yoruz

        if (isOpen)
        {
            transform.rotation = Quaternion.Lerp(currentRot, newRot, 0.2f);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(currentRot, startRot, 0.2f);
        }
    }

    public void CheckDoor()
    {
        if (!isLocked)
        {
            isOpen = !isOpen;
        }
    }
}
