using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class SecondCreateEvent : MonoBehaviour
{
    DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
    private string characters = "123456789qwertyuiopasdfghjkzxcvbnmQWERTYUPASDFGHJKLZXCVBNM";
    string code;
    DatabaseReference reference;
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            int a = UnityEngine.Random.Range(0, characters.Length);
            code = code + characters[a];
        }

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError(
                  "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    protected virtual void InitializeFirebase()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;
        // NOTE: You'll need to replace this url with your Firebase App's database
        // path in order for the database connection to work correctly in editor.
        app.SetEditorDatabaseUrl("https://scanup-6afda.firebaseio.com/");
        FirebaseDatabase database = FirebaseDatabase.DefaultInstance;

        reference = FirebaseDatabase.DefaultInstance.RootReference;
        reference = database.GetReference("Events/" + code);
        if (app.Options.DatabaseUrl != null) app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);
        reference.RunTransaction(mutableData =>
        {
            List<object> leaders = mutableData.Value as List<object>;
            Dictionary<string, object> newScoreMap = new Dictionary<string, object>();
            newScoreMap["code"] = code;
            leaders.Add(newScoreMap);

            // You must set the Value to indicate data at that location has changed.
            mutableData.Value = leaders;
            //return and log success
            return TransactionResult.Success(mutableData);
        });
        //StartListener();
    }

    protected void StartListener()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Events").ValueChanged += (object sender2, ValueChangedEventArgs e2) => {
             if (e2.DatabaseError != null)
              {
                  Debug.LogError(e2.DatabaseError.Message);
                  return;
              }
              Debug.Log("Received values for Leaders.");
              if (e2.Snapshot != null && e2.Snapshot.ChildrenCount > 0)
              {
                  foreach (var childSnapshot in e2.Snapshot.Children)
                  {
                }
              }
          };
    }

    TransactionResult AddScoreTransaction(MutableData mutableData)
    {
        List<object> leaders = mutableData.Value as List<object>;

        Dictionary<string, object> newScoreMap = new Dictionary<string, object>();
        newScoreMap["code"] = code;

        leaders.Add(newScoreMap);


        mutableData.Value = leaders;
        //return and log success
        return TransactionResult.Success(mutableData);
    }

    public void AddScore()
    {

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("Events");

        Debug.Log("Running Transaction...");
        // Use a transaction to ensure that we do not encounter issues with
        // simultaneous updates that otherwise might create more than MaxScores top scores.
        reference.RunTransaction(AddScoreTransaction)
          .ContinueWith(task => {
              if (task.Exception != null)
              {
                  Debug.Log(task.Exception.ToString());
              }
              else if (task.IsCompleted)
              {
                  Debug.Log("Transaction complete.");
              }
          });
    }
}
