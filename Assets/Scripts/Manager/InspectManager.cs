using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;  //ana karakterin scriptine eri�ebilmek i�in ekledik
public class InspectManager : MonoBehaviour
{
    public float distance;
    public Transform playerSocket; //nesneyi elimize ald��m�zda bulunaca�� konumu
    Vector3 originalPos; //objenin as�l yeri (yani elimizden b�rakt���mzdaki yeri)
    bool onInspect=false;
    GameObject inspected; //incelemi� oldu�umuz obje
    public FirstPersonController playerScript;

    public GameObject activisionKey;
    public GameObject dropText;
    void Start()
    {
        
    }

   
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward); //karakterden ��kacak olan ray'i tan�mlad�k
        RaycastHit hit;

        if(Physics.Raycast(transform.position,fwd,out hit, distance)) //benden ��kan ray bir yere �arp�yor mu diye kontrol ediyoruz 
        {
            if (hit.transform.tag == "Object")
            {
                activisionKey.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    inspected = hit.transform.gameObject; //bu �artlar� sa�l�yorsa insptected olsun 
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
            playerSocket.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime*125f); //objeyi elimize ald���m�zda d�nerek gelecek
        }

        else if(inspected != null)
        {
            inspected.transform.SetParent(null);
            inspected.transform.position = Vector3.Lerp(inspected.transform.position, originalPos, 0.2f); //incelenen nesneyi masaya geri koyma i�lemi
        }

        if (Input.GetKeyDown(KeyCode.G) && onInspect) //incelenen objeyi geri b�rakma i�lemi
        {
            StartCoroutine(DropItem());
            onInspect = false;
        }

        IEnumerator PickupItem()
        {
            playerScript.enabled = false; //elimde ob�e varken hareket edemiyim
            dropText.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            inspected.transform.SetParent(playerSocket);
        }

        IEnumerator DropItem()
        {
            inspected.transform.rotation = Quaternion.identity; //masaya b�rak�lan nesne ald���m�z �ekilde yerine koyulur
            dropText.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            playerScript.enabled = true; //art�k hareket edebiliriz.
            
        }
    }
}
