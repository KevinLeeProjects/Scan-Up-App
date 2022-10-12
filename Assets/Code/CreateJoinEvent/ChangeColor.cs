using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{

    public Text join;
    public Text create;
    float r = 0.1f, g = 0.4f, b = 0.9f, a = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        //join = gameObject.GetComponent<Text>();
        join.color = new Color(r, g, b,a );
        create.color = new Color(r, g, b, a);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
