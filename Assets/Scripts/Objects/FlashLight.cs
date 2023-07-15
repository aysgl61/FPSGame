using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    Light fLight;
    public bool drainOverTime; //zamanla fenerin ýþýðý azalacak
    public float maxBrightness;  //ýþýðýn yoðunluðunun max ve min sýnýrýný belirledik.
    public float minBrightness;
    public float drainRate;  //ýþýðýn hangi hýzla azalacaðýný belirledik
    void Start()
    {
        fLight = GetComponent<Light>();
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            fLight.enabled = !fLight.enabled; //f tuþuna basýnca ýþýk yanýyorsa sönecek, sönük ise yanacak
        }

        if (drainOverTime==true && fLight.enabled==true) 
        {
            fLight.intensity = Mathf.Clamp(fLight.intensity, minBrightness, maxBrightness); //clamp-> bir deðerin min ve max deðerleri arasýnda deðer almasýný belirler.
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
