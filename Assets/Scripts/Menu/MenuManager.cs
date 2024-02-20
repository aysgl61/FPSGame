using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject FadeOut;
    [SerializeField]
    GameObject loadingTxt;
    [SerializeField]
    GameObject hintTxt;

    public void NewGameButton()
    {
        StartCoroutine(NewGame());
    }

    IEnumerator NewGame()
    {
        FadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        loadingTxt.SetActive(true);
        hintTxt.SetActive(true);
        SceneManager.LoadScene(0);
    }
}
