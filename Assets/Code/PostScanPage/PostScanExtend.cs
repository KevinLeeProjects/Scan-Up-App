using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostScanExtend : MonoBehaviour
{

    public string bothname;
    public string signouttime;
    public string signintime;
    public string signinstatus;
    public string totalhours;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PostScanExtend(string bothname, string signouttime, string signintime, string signinstatus, string totalhours)
    {
        this.bothname = bothname;
        this.signouttime = signouttime;
        this.signintime = signintime;
        this.signinstatus = signinstatus;
        this.totalhours = totalhours;
    }
}
