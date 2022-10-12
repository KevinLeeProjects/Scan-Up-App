using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;
using Firebase.Unity.Editor;

public class EventName : MonoBehaviour
{
    public Text text;

    public DatabaseReference reference;

    public FirebaseDatabase database;

    string testcode;


    // Start is called before the first frame update
    void Start()
    {
        Firebase.FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://scanup-6afda.firebaseio.com/");
        database = FirebaseDatabase.DefaultInstance;
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        if (HomeCode.joinedorcreated == 2)
        {
            reference = database.GetReference("Events/" + CreateEvent.eventcode);
            testcode = CreateEvent.eventcode;
        }
        else if (HomeCode.joinedorcreated == 1)
        {
            reference = database.GetReference("Events/" + JoinEvent.joinedcode);
            testcode = JoinEvent.joinedcode;
        }

        reference = reference.Child("eventname");

        StartCoroutine(ToTest(reference, database));
    }

    IEnumerator ToTest(DatabaseReference refer, FirebaseDatabase data)
    {
        var getTask = refer.GetValueAsync();
        yield return new WaitUntil(() => getTask.IsCompleted || getTask.IsFaulted);
        if (getTask.IsCompleted)
        {
            text.text = getTask.Result.Value.ToString();
        }
    }
}
