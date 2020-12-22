using UnityEngine;
using System;
using ZXing;
using UnityEngine.UI;

public class ScannerQR : MonoBehaviour
{
    public Camera cam;
    public Text debugText;
    private BarcodeReader barCodeReader;
    private FrameCapturer pixelCapturer;

    private void Start()
    {
        barCodeReader = new BarcodeReader();
        Resolution currentResolution = Screen.currentResolution;
        pixelCapturer = cam.GetComponent<FrameCapturer>();
    }

    private void Update()
    {
        Resolution currentResolution = Screen.currentResolution;
        try
        {
            Color32[] framebuffer = pixelCapturer.lastCapturedColors;
            if (framebuffer.Length == 0)
            {
                return;
            }
            var data = barCodeReader.Decode(framebuffer, currentResolution.width, currentResolution.height);
            if (data != null)
            {
                string qr = "QR " + data.Text;
                debugText.text = qr;
            }

        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
        pixelCapturer.shouldCaptureOnNextFrame = true;
    }
}
