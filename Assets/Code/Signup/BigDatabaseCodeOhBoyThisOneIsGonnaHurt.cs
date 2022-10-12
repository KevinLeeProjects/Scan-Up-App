using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase.Database;
using Firebase.Auth;
using Firebase.Unity.Editor;

public class BigDatabaseCodeOhBoyThisOneIsGonnaHurt : MonoBehaviour
{
    public FirebaseAuth auth;


    public Button signupbutton;

    public FirebaseDatabase database;

    public string authid;

    public static string userid;

    public InputField first;
    public InputField last;
    public InputField users;
    public InputField em;
    public InputField pass;
    public InputField cpass;

    DatabaseReference reference;

    void Start()
    {
        userid = "";

       
        signupbutton.onClick.AddListener(() => Signup(em.text, pass.text));
    }


    void Update()
    {

    }

    public void OnMouseDown()
    {
        if(Check())
        {
            auth = FirebaseAuth.DefaultInstance;

            Firebase.FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://scanup-6afda.firebaseio.com/");
            database = FirebaseDatabase.DefaultInstance;

            reference = FirebaseDatabase.DefaultInstance.RootReference;

            reference = database.GetReference("UserID");
            StartCoroutine(ToTest(reference, database));

        }
        else
        {
            Debug.LogFormat("Nah Fam");
        }
    }

    public bool Check()
    {
        if(cpass.text.Equals("") || pass.text.Equals("") || em.text.Equals("") || users.text.Equals("") || last.text.Equals("") || first.text.Equals(""))
        {
            return false;
        }
        else if (cpass.text.Equals(pass.text))
        {
            return true;
        }
        return false;
    }

    public void Signup(string mail, string pw)
    {
        if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(pw))
        {
            //Error handling
            return;
        }

        auth.CreateUserWithEmailAndPasswordAsync(mail, pw).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync error: " + task.Exception);
                if (task.Exception.InnerExceptions.Count > 0)
                    UpdateErrorMessage(task.Exception.InnerExceptions[0].Message);
                return;
            }

            FirebaseUser newUser = task.Result; // Firebase user has been created.
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            //username = newUser.UserId;
            userid = newUser.UserId;
            UpdateErrorMessage("Signup Success");
        });
    }

    private void UpdateErrorMessage(string message)
    {
        //ErrorText.text = message;
        Invoke("ClearErrorMessage", 3);
    }

    void ClearErrorMessage()
    {
        //ErrorText.text = "";
    }

    IEnumerator ToTest(DatabaseReference refer, FirebaseDatabase data)
    {

        print(Time.time);
        yield return new WaitForSeconds(2);
        {
            database = FirebaseDatabase.DefaultInstance;
            reference = FirebaseDatabase.DefaultInstance.RootReference;

            reference = database.GetReference("UserID/" + userid);
            ActualCode(reference);
        }
        print(Time.time);

    }

    public void ActualCode(DatabaseReference refer)
    {
        ExtendCode user = new ExtendCode(first.text + " " + last.text, em.text, first.text, last.text, pass.text, users.text);
        string json = JsonUtility.ToJson(user);
        refer.SetRawJsonValueAsync(json);

        SceneManager.LoadScene("SampleScene");
    }
}
