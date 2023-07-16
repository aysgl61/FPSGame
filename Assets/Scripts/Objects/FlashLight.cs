using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    Light fLight;
    public bool drainOverTime; //zamanla fenerin ����� azalacak
    public float maxBrightness;  //�����n yo�unlu�unun max ve min s�n�r�n� belirledik.
    public float minBrightness;
    public float drainRate;  //�����n hangi h�zla azalaca��n� belirledik
    void Start()
    {
        fLight = GetComponent<Light>();
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            fLight.enabled = !fLight.enabled; //f tu�una bas�nca ���k yan�yorsa s�necek, s�n�k ise yanacak
        }

        if (drainOverTime==true && fLight.enabled==true) 
        {
            fLight.intensity = Mathf.Clamp(fLight.intensity, minBrightness, maxBrightness); //clamp-> bir de�erin min ve max de�erleri aras�nda de�er almas�n� belirler.
            if(fLight.intensity > minBrightness) //pilin varsa
            {
                fLight.intensity -= Time.deltaTime*(drainRate /1000);
            }
        }
        else if(drainOverTime==true && fLight.enabled == false)
        {
            if(fLight.intensity < maxBrightness)
            {
                fLight.intensity += Time.deltaTime * (drainRate / 1000);
            }
        }
    }
}
