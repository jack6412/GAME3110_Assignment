using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogInScreap : MonoBehaviour
{
    public GameObject Registration_Scream;
    public GameObject Login_Scream;

    //Registration message use
    public GameObject message;
    public Text Message_Text;

    //Registration section
    public InputField UserName;
    public InputField Password;
    public InputField Check_Password;

    //Login Section
    public InputField User;
    public InputField Check;

    //Login message
    public GameObject L_message;
    public Text L_Message_Text;

    public void confirm()
    {
        message.gameObject.SetActive(true);

        //Check User name
        if(UserName.text == "")//check empty user name
            Message_Text.text = "Please enter user name.";

        else if (UserName.text == "jack")//check empty exit
            Message_Text.text = "User Already exit.";

        else
        { 
            //check password
            if (Password.text == "" || Check_Password.text == "")//check password is empty
                Message_Text.text = "Please Enter your Password.";
            
            else if (Password.text == Check_Password.text)//check password is match
            {
                Message_Text.text = "User Confirm.";

            }
            else
                Message_Text.text = "Password not matck";

        }
    }

    public void Regitsration()
    {
        Registration_Scream.gameObject.SetActive(true);
        Login_Scream.gameObject.SetActive(false);
        L_message.gameObject.SetActive(false);
    }

    public void Return()
    {
        Registration_Scream.gameObject.SetActive(false);
        Login_Scream.gameObject.SetActive(true);
        message.gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Login()
    {
        if (User.text == "")//check empty user name
        {
            L_message.gameObject.SetActive(true);

            L_Message_Text.text = "Please enter user name.";
        }
        else
        {
            //check password
            if (Check.text == "")//check password is empty
            {
                L_message.gameObject.SetActive(true);
                L_Message_Text.text = "Please Enter your Password.";
            }

            else if (Check.text == "1" && User.text == "jack")//check password and user name is match
            {
                L_message.gameObject.SetActive(false);
                SceneManager.LoadScene("MainMenu");

            }
            else
            {
                L_message.gameObject.SetActive(true);
                L_Message_Text.text = "User name or Password not matck";
            }

        }
    }
}
