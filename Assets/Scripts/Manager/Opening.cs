using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson; // first person controller'a erişmek için ekledik
using UnityEngine.UI;
public class Opening : MonoBehaviour
{
    public GameObject player;
    public GameObject fadeScreen;
    public GameObject text; //alt yazı için

    private void Start()
    {
        player.GetComponent<FirstPersonController>().enabled = true; //oyunun başında karakter hareket edemesin
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        fadeScreen.SetActive(false);
        text.GetComponent<Text>().text = "Aman Yarabbi neredeyim ben!! ";
        yield return new WaitForSeconds(2f);
        text.GetComponent<Text>().text = "";
        player.GetComponent<FirstPersonController>().enabled = true;
    }
 }
