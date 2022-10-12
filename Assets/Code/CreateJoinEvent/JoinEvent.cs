using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JoinEvent : MonoBehaviour
{

    public DatabaseReference reference;

    public FirebaseDatabase database;

    public InputField join;

    public int joincounter;

    public static string joinedcode;
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
        HomeCode.joinedorcreated = 1;
        Firebase.FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://scanup-6afda.firebaseio.com/");
        database = FirebaseDatabase.DefaultInstance;
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        reference = database.GetReference("Events/" + join.text);
        reference = reference.Child("joineduserscounter");
        StartCoroutine(ToTest(join.text, database, reference));

    }

    IEnumerator ToTest(string code,  FirebaseDatabase data, DatabaseReference refer)
    {

        string joincode = join.text;


        joinedcode = joincode;

        var getTask = refer.GetValueAsync();
        yield return new WaitUntil(() => getTask.IsCompleted || getTask.IsFaulted);
        if(getTask.IsCompleted)
        {;
            joincounter = int.Parse(getTask.Result.Value.ToString());
            joincounter++;
            refer = data.GetReference("Events/" + code);
            ActualCode(refer);
            reference = data.GetReference("Events/" + code + "/" + "Joinedusers" + int.Parse(getTask.Result.Value.ToString()));
            SecondActualCode(reference);
        }
    }

    public void ActualCode(DatabaseReference refer)
    {
        JoinUserCounterExtend entry = new JoinUserCounterExtend(joincounter);
        Dictionary<string, object> entryValues = entry.ToDictionary();
        refer.UpdateChildrenAsync(entryValues);
        
    }

    public void SecondActualCode(DatabaseReference refer)
    {
        HopefullyFinalExtend user = new HopefullyFinalExtend(Login.username);
        string json = JsonUtility.ToJson(user);
        refer.SetRawJsonValueAsync(json);
        SceneManager.LoadScene("Scanner Page");
    }
}
