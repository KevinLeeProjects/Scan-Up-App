using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostScanOtherExtend : MonoBehaviour
{

    public int joinedscannedusers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PostScanOtherExtend(int joinedscannedusers)
    {
        this.joinedscannedusers = joinedscannedusers;
    }

    public Dictionary<string, object> ToDictionary()
    {
        Dictionary<string, object> result = new Dictionary<string, object>();
        result["joinedscannedusers"] = joinedscannedusers;

        return result;
    }
}
