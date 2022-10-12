using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using ZXing.Common;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;


public class QRCodeGeneratorPlSWoRk : MonoBehaviour
{

    public RawImage testimage;

    public int width;
    public int height;
    [SerializeField] private BarcodeFormat format = BarcodeFormat.QR_CODE;

    void Start()
    {
        
        height = Screen.height;
        width = Screen.width;


        var color32 = Encode(Login.username, format, width, height, testimage);


    }




    private static Texture2D Encode(string data, BarcodeFormat format, int width, int height, RawImage test)
    {
        BitMatrix bitMatrix = new MultiFormatWriter()
        .encode(data, format, width, height);

        Color[] pixels = new Color[bitMatrix.Width * bitMatrix.Height];
        int pos = 0;
        for (int y = 0; y < bitMatrix.Height; y++)
        {
            for (int x = 0; x < bitMatrix.Width; x++)
            {
                pixels[pos++] = bitMatrix[x, y] ? Color.blue : Color.clear;
            }
        }
        var encoded = new Texture2D(width, height);
        encoded.SetPixels(pixels);
        encoded.Apply();
        var created = Sprite.Create(encoded, new Rect((float)(Screen.width * .2), (float)(Screen.height * .3), (float)(Screen.width * .7), (float)(Screen.height * .7)),new Vector2(0,0));
        test.GetComponent<RawImage>().texture = encoded;
        return encoded;
    }



}
