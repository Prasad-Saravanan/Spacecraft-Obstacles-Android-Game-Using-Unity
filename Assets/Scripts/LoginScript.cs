using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;

public class LoginScript : MonoBehaviour
{

    public GameObject username;
    public GameObject password;
    public GameObject login;

    public Button btnLogin;

    private string Username;
    private string Password;

    //Progress bar components
    public GameObject ProgressPanel;
    public Transform LoadingBar;

    [SerializeField] private float currentAmmount = 1;
    [SerializeField] private float speed = 1;


    // Use this for initialization
    void Start()
    {
        //Here in start , we are going to hide the progress bar 
        ProgressPanel.SetActive(false); //false to hide the panel with the child to be true to show.

        Screen.orientation = ScreenOrientation.Portrait;

    }

    // Update is called once per frame
    void Update()
    {
        //set data to String from input field.
        //change Progress when Progress panel is active
        if (ProgressPanel.activeSelf)
        {

            if (currentAmmount < 100)
            {
                currentAmmount += currentAmmount * speed;
                LoadingBar.GetComponent<Image>().fillAmount = currentAmmount / 100; //basically fill amount take value between 0 to 100.
            }
            else
            {
                //if progress complete to 100 restart it from 1
                currentAmmount = 1;
                LoadingBar.GetComponent<Image>().fillAmount = currentAmmount / 100;
            }

        }

        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;

        btnLogin = login.GetComponent<Button>();
        btnLogin.onClick.AddListener(validateLogin);
    }
    private void validateLogin()
    {

        //Here will show Progress bar. 
        ProgressPanel.SetActive(true);

        if (Username != "" && Password != "")
        {
            print("LoginSuccess!");
            SceneManager.LoadScene(1);
        }
        else
        {
            print("LoginFailed");
        }
    }
}
