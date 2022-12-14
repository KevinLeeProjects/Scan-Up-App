using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

public class OtherQRCodeGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private static Color32[] Encode(string textForEncoding,
  int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }

    public Texture2D generateQR(string text)
    {
        var encoded = new Texture2D(512, 512);
        var color32 = Encode(text, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        
        encoded.Apply();
        return encoded;
    }

    private void OnGUI()
    {
        Texture2D myQR = generateQR("test");
        if (GUI.Button(new Rect(300, 300, 512, 512), myQR, GUIStyle.none)) { }
    }

    void Update()
    {
        
    }


}
