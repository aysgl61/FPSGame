using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShot : MonoBehaviour
{
    public GameObject head;
    public GameObject blood;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    //head disable oldu�unda bu fonk �al��acak
    private void OnDisable()
    {
        head.SetActive(false);
        blood.SetActive(true);
    }
}
