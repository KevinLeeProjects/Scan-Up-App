using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class Login : MonoBehaviour
{

    public static int logintest;

    public static string username;

    private FirebaseAuth auth;
    public InputField UserNameInput, PasswordInput;
    public Button LoginButton;
    public Text ErrorText;
    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        auth.SignOut();
        LoginButton.onClick.AddListener(() => LoginPlease(UserNameInput.text, PasswordInput.text));

    }

    private void UpdateErrorMessage(string message)
    {
        ErrorText.text = message;
        Invoke("ClearErrorMessage", 3);
    }

    void ClearErrorMessage()
    {
        ErrorText.text = "";
    }

    public void LoginPlease(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                logintest = 0;
                Debug.LogError("SignInWithEmailAndPasswordAsync canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                logintest = 0;
                Debug.LogError("SignInWithEmailAndPasswordAsync error: " + task.Exception);
                if (task.Exception.InnerExceptions.Count > 0)
                    UpdateErrorMessage(task.Exception.InnerExceptions[0].Message);
                return;
            }

            logintest = 1;

            FirebaseUser user = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                user.DisplayName, user.UserId);
            Debug.LogFormat(logintest.ToString());
            username = user.UserId;
            PlayerPrefs.SetString("LoginUser", user != null ? user.Email : "Unknown");
           

        });
        StartCoroutine(toTest());

    }


    IEnumerator toTest()
    {
        yield return new WaitForSeconds(2);
        if(logintest == 1)
        {
            SceneManager.LoadScene("HomePage");
            logintest = 0;
        }

    }
}