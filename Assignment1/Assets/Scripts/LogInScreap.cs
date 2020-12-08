using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogInScreap : MonoBehaviour
{
    public GameObject Registration_Scream;
    public GameObject Login_Scream;

    public void Regitsration()
    {
        Registration_Scream.gameObject.SetActive(true);
        Login_Scream.gameObject.SetActive(false);
    }

    public void Login()
    {
        Registration_Scream.gameObject.SetActive(false);
        Login_Scream.gameObject.SetActive(true);
    }
}
