using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScanner : MonoBehaviour
{
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
        StartCoroutine(ToTest());

    }

    IEnumerator ToTest()
    {
        yield return new WaitForSeconds(3);
        {
            SceneManager.LoadScene("CreateJoinEvent");
        }
    }
}
