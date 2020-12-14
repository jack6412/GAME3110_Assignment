using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinLosingScenes : MonoBehaviour
{
    public GameObject ButtonAction;
    public GameObject WinUI;

    public void ButtonRestart()
    {
        WinUI.gameObject.SetActive(false);
        ButtonAction.gameObject.SetActive(true);
        SceneManager.LoadScene("PickNumber");
    }

    public void ButtonQuit()
    {
        WinUI.gameObject.SetActive(false);
        ButtonAction.gameObject.SetActive(true);
        SceneManager.LoadScene("Login");
    }
}
