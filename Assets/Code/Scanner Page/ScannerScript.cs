using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using ZXing.Common;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScannerScript : MonoBehaviour
{
    public RawImage rawimage;

    private WebCamTexture mCamera = null;
    private WebCamTexture cCamera = null;
    public GameObject plane;
    public static string usercode;

    private Rect screenRect;

    void Start()
    {

        screenRect = new Rect(0, 0, Screen.width, Screen.height/2);
        WebCamTexture webcamTexture = new WebCamTexture();
        rawimage.texture = webcamTexture;
        cCamera = (UnityEngine.WebCamTexture)rawimage.texture;
        rawimage.material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }

    void OnGUI()
    {
        GUI.DrawTexture(screenRect, mCamera, ScaleMode.ScaleToFit);
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();

            var result = barcodeReader.Decode(cCamera.GetPixels32(), cCamera.width, cCamera.height);
            if (result != null)
            {
                Debug.Log("DECODED TEXT FROM QR: " +result.Text);
                usercode = result.Text;
                SceneManager.LoadScene("PostScanPage");
            }
        }
        catch (Exception ex) { Debug.LogWarning(ex.Message); }
        }
    }
