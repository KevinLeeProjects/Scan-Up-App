using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondOtherExtend : MonoBehaviour
{

    public string creator;
    public string eventname;
    public int joineduserscounter;
    public int joinedscannedusers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public SecondOtherExtend(string creator, string eventname, int joineduserscounter,int joinedscannedusers)
    {
        this.creator = creator;
        this.eventname = eventname;
        this.joineduserscounter = joineduserscounter;
        this.joinedscannedusers = joinedscannedusers;
    }
}
