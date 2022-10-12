using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpreadsheetBigBoiCode : MonoBehaviour
{

    public Text text;
    float a;
    // Start is called before the first frame update
    void Start()
    {
        //OnGUI();
        a = (float)(Screen.width * .05);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGUI()
    {

        GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
        myButtonStyle.fontSize = (int)a;
        // Load and set Font
        Font myFont = (Font)Resources.Load("Fonts/comic", typeof(Font));
        myButtonStyle.font = myFont;
        myButtonStyle.normal.background = Texture2D.whiteTexture;
        // Set color for selected and unselected buttons
        myButtonStyle.normal.textColor = Color.black;
        myButtonStyle.hover.textColor = Color.black;
 // use style in button
    bool testButtonTwo = GUI.Button(new Rect((float)(Screen.width * .1), (float)(Screen.height * .1),(float)(Screen.width * .8), (float)(Screen.height * .8)), ToSpreadsheet.list, myButtonStyle);
    }

    public Rect MakeRect(string label)
    {
        Rect labelRect = GUILayoutUtility.GetRect(new GUIContent(label), "label");
        return labelRect;
    }


}
