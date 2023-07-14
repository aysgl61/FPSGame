using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;  //ana karakterin scriptine eriþebilmek için ekledik
public class InspectManager : MonoBehaviour
{
    public float distance;
    public Transform playerSocket; //nesneyi elimize aldðýmýzda bulunacaðý konumu
    Vector3 originalPos; //objenin asýl yeri (yani elimizden býraktýðýmzdaki yeri)
    bool onInspect=false;
    GameObject inspected; //incelemiþ olduðumuz obje
    public FirstPersonController playerScript;

    public GameObject activisionKey;
    public GameObject dropText;
    void Start()
    {
        
    }

   
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward); //karakterden çýkacak olan ray'i tanýmladýk
        RaycastHit hit;

        if(Physics.Raycast(transform.position,fwd,out hit, distance)) //benden çýkan ray bir yere çarpýyor mu diye kontrol ediyoruz 
        {
            if (hit.transform.tag == "Object")
            {
                activisionKey.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    inspected = hit.transform.gameObject; //bu þartlarý saðlýyorsa insptected olsun 
                    originalPos = hit.transform.position;
                    onInspect = true;
                    StartCoroutine(PickupItem());
                }
            }
            else
            {
                activisionKey.SetActive(false);
            }
        }

        if (onInspect)
        {
            inspected.transform.position = Vector3.Lerp(inspected.transform.position, playerSocket.position, 0.2f);
            playerSocket.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime*125f); //objeyi elimize aldýðýmýzda dönerek gelecek
        }

        else if(inspected != null)
        {
            inspected.transform.SetParent(null);
            inspected.transform.position = Vector3.Lerp(inspected.transform.position, originalPos, 0.2f); //incelenen nesneyi masaya geri koyma iþlemi
        }

        if (Input.GetKeyDown(KeyCode.G) && onInspect) //incelenen objeyi geri býrakma iþlemi
        {
            StartCoroutine(DropItem());
            onInspect = false;
        }

        IEnumerator PickupItem()
        {
            playerScript.enabled = false; //elimde obþe varken hareket edemiyim
            dropText.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            inspected.transform.SetParent(playerSocket);
        }

        IEnumerator DropItem()
        {
            inspected.transform.rotation = Quaternion.identity; //masaya býrakýlan nesne aldýðýmýz þekilde yerine koyulur
            dropText.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            playerScript.enabled = true; //artýk hareket edebiliriz.
            
        }
    }
}
