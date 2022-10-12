using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;

public class PostScanName : MonoBehaviour
{
    public Text testtext;

    DatabaseReference reference;
    // Start is called before the first frame update
    void Start()
    {

        Firebase.FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://scanup-6afda.firebaseio.com/");
        FirebaseDatabase database = FirebaseDatabase.DefaultInstance;
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        FirebaseDatabase.DefaultInstance.GetReference("Events/" + ScannerScript.usercode).Child("bothname").ValueChanged += (object sender2, ValueChangedEventArgs e2) =>
        {
            foreach (var childSnapshot in e2.Snapshot.Children)
            {
                Debug.LogFormat(childSnapshot.Value.ToString());
            }
        };
    }

    IEnumerator toTest(DatabaseReference refer, FirebaseDatabase data)
    {


        refer = data.GetReference("UserID/" + ScannerScript.usercode);
        refer = refer.Child("bothname");
        var getTask = refer.GetValueAsync();

        yield return new WaitForSeconds(1);
        {
            Debug.Log("Try:" + getTask.Result.Value.ToString());
            testtext.text = getTask.Result.Value.ToString();
        }


    }
}
