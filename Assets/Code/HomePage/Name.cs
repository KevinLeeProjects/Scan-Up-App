using System.Collections;
using System.Collections.Generic;
using Firebase.Auth;
using Firebase.Database;
using UnityEngine;
using Firebase.Unity.Editor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Name : MonoBehaviour
{

    //private FirebaseAuth auth;
    //private FirebaseDatabase database;
    DatabaseReference reference;

    public Text name2;

   
    // Start is called before the first frame update
    void Start()
    {
        Firebase.FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://scanup-6afda.firebaseio.com/");
        FirebaseDatabase database = FirebaseDatabase.DefaultInstance;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseDatabase.DefaultInstance.GetReference("UserID").GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                // Handle the error...
                Debug.Log("ERROR");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                // Do something with snapshot...
            }
        });
    }

    IEnumerator toTest(DatabaseReference refer, FirebaseDatabase data)
    {


        refer = data.GetReference("UserID/" + Login.username);
        refer = refer.Child("bothname");
        var getTask = refer.GetValueAsync();

        yield return new WaitForSeconds(1);
        {    
            name2.text = getTask.Result.Value.ToString();
        }


    }

}
