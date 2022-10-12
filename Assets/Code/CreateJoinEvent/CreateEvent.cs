using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase.Database;
using System;
using Firebase.Unity.Editor;

public class CreateEvent : MonoBehaviour
{

    public Text text;

    public string eventname;
    public static string eventcode;
    private string characters = "123456789qwertyuiopasdfghjkzxcvbnmQWERTYUPASDFGHJKLZXCVBNM";

    DatabaseReference reference;

    DatabaseReference newreference;

    public InputField eventname1;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnMouseDown()
    {
        HomeCode.joinedorcreated = 2;
        Firebase.FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://scanup-6afda.firebaseio.com/");
        FirebaseDatabase database = FirebaseDatabase.DefaultInstance;

        reference = FirebaseDatabase.DefaultInstance.RootReference;
       


        eventname = eventname1.text;
        Debug.LogFormat(eventname1.text);
        string code = "";

        for (int i = 0; i < 9; i++)
        {
            int a = UnityEngine.Random.Range(0, characters.Length);
            code = code + characters[a];
        }

        reference = database.GetReference("Events/" + code);
        Debug.LogFormat(reference.ToString());
        Debug.LogFormat(code);
        StartCoroutine(ToTest(code, reference));
    }

    IEnumerator ToTest(string code1, DatabaseReference refer)
    {
        print(Time.time);
        yield return new WaitForSeconds(2);
        {
            ActualCode(code1, refer);
        }

    }

    public void ActualCode(string code2, DatabaseReference refer)
    {
        print(Time.time);
        eventname = eventname1.text;
        eventcode = code2;
        SecondOtherExtend newuser = new SecondOtherExtend(Login.username, eventname, 0, 0);
        string json1 = JsonUtility.ToJson(newuser);
        refer.SetRawJsonValueAsync(json1);
        SceneManager.LoadScene("Scanner Page");
    }
}
