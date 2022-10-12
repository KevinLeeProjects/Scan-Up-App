using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;
using Firebase.Unity.Editor;

public class PostScanCode : MonoBehaviour
{
    public static string name2;
    public Text testtext;
    DatabaseReference reference;
    int scannedincounter;
    string testcode;
    float a;
    // Start is called before the first frame update
    void Start()
    {

        Firebase.FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://scanup-6afda.firebaseio.com/");
        FirebaseDatabase database = FirebaseDatabase.DefaultInstance;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        a = (float)(Screen.width * .03);

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
        reference = reference.Child("joinedscannedusers");

        StartCoroutine(ToTest(reference, database));
    }

    IEnumerator ToTest(DatabaseReference refer, FirebaseDatabase data)
    {


        var getTask = refer.GetValueAsync();

        yield return new WaitUntil(() => getTask.IsCompleted || getTask.IsFaulted);
        if (getTask.IsCompleted)
        {
            scannedincounter = int.Parse(getTask.Result.Value.ToString());
            scannedincounter++;

            refer = data.GetReference("Events/" + testcode);
            ActualCode(refer);
            reference = data.GetReference("Events/" + testcode + "/" + "Scannedinusers" + int.Parse(getTask.Result.Value.ToString()));
            SecondActualCode(reference);
            refer = data.GetReference("UserID/" + ScannerScript.usercode);
            refer = refer.Child("bothname");
            SecondTest(refer, data);
        }

    }

    public void SecondActualCode(DatabaseReference refer)
    {
        Hopefullyfinaljoincreateextend user = new Hopefullyfinaljoincreateextend(ScannerScript.usercode);
        string json = JsonUtility.ToJson(user);
        refer.SetRawJsonValueAsync(json);

    }

    public void ActualCode(DatabaseReference refer)
    {
        PostScanOtherExtend entry = new PostScanOtherExtend(scannedincounter);
        Dictionary<string, object> entryValues = entry.ToDictionary();
        refer.UpdateChildrenAsync(entryValues);
    }


    IEnumerator SecondTest(DatabaseReference refer, FirebaseDatabase data)
    {
        var getTask = refer.GetValueAsync();
        yield return new WaitForSeconds(2);
        {
            testtext.text = getTask.Result.Value.ToString();

        }
    }
}
