using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinUserCounterExtend : MonoBehaviour
{
    public int joineduserscounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public JoinUserCounterExtend(int joineduserscounter)
    {
        this.joineduserscounter = joineduserscounter;
    }

    public Dictionary<string, object> ToDictionary()
    {
        Dictionary<string, object> result = new Dictionary<string, object>();
        result["joineduserscounter"] = joineduserscounter;

        return result;
    }
}
