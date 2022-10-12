using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase.Database;
using Firebase.Unity.Editor;

public class ToSpreadsheet : MonoBehaviour
{
    List<string> ar = new List<string>();
    DatabaseReference reference;
    public static string list;
    void Start()
    {
    }

    public void ToSecondTest(DatabaseReference refer, FirebaseDatabase data)
    {
    }



    public void OnMouseDown()
    {

        SceneManager.LoadScene("Spreadsheet");
    }
}
