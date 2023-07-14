using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class Keypad : MonoBehaviour
{
    public DoorController doorToOpen;
    public GameObject keypadUI;
    public Text passwordText;
    public string password;
    public GameObject dropText;
    public FirstPersonController playerScript;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            playerScript.enabled = true;
            keypadUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            keypadUI.SetActive(true);
            playerScript.enabled = false; //password canvasý ekrana geldiðinde mouse görünür olsun
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            dropText.SetActive(true);
        }
    }

    public void KeyButton(string key) //1'e basarsak ekranda 1 yazmasýný saðlar
    {
        passwordText.text = passwordText.text + key;
    }

    public void ResetPassword() //kýrmýzý butona basýnca þifre sýfýrlansýn
    {
        passwordText.text = "";
    }

    public void CheckPassword()
    {
        if(passwordText.text== password)
        {
            doorToOpen.isLocked = false;
            doorToOpen.CheckDoor();
            keypadUI.SetActive(false);
            playerScript.enabled = true;
        }

        else
        {
            ResetPassword();
        }
    }
}
