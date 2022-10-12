using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendCode : MonoBehaviour
{

    public string bothname;
    public string email;
    public string firstname;
    public string lastname;
    public string password;
    public string signintime;
    public string signout;
    public string signouttime;
    public string username;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public ExtendCode(string bothname, string email, string firstname, string lastname, string password, string username)
    {
            this.bothname = bothname;
            this.email = email;
            this.username = username;
            this.firstname = firstname;
            this.lastname = lastname;
            this.password = password;
            this.signintime = "0";
            this.signout = "0";
            this.signouttime = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
