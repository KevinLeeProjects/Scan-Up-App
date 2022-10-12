using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OtherCreateEvent : MonoBehaviour
{

    DatabaseReference reference;

    public Button enterbutton;

    void Start()
    {
        enterbutton.onClick.AddListener(() => CreateCreator());
    }

    public void CreateCreator()
    {


        StartCoroutine(ToTest());
    }

    IEnumerator ToTest()
    {
        print(Time.time);

        yield return new WaitForSeconds(3);
        {
            Firebase.FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://scanup-6afda.firebaseio.com/");
            FirebaseDatabase database = FirebaseDatabase.DefaultInstance;

            reference = FirebaseDatabase.DefaultInstance.RootReference;

            reference = database.GetReference("UserID/" + "Events/" + CreateEvent.eventcode);
            ActualCode();
        }
    }

    public void ActualCode()
    {
        SecondOtherExtend moreextend = new SecondOtherExtend(Login.username, "EVENT",0 , 0);
        string json = JsonUtility.ToJson(moreextend);
        reference.SetRawJsonValueAsync(json);
    }
}
