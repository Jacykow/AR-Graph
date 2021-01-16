using System;
using UnityEngine;
using ZXing;

public class ScannerQR : MonoBehaviour
{
    public Camera cam;
    private BarcodeReader barCodeReader;
    private FrameCapturer pixelCapturer;

    private void Start()
    {
        barCodeReader = new BarcodeReader();
        pixelCapturer = cam.GetComponent<FrameCapturer>();
    }

    private void Update()
    {
        pixelCapturer.shouldCaptureOnNextFrame = true;

        if (DataManager.Main.ScanningQRProperty.Value == false)
        {
            return;
        }

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
                string qr = data.Text;
                if (qr != DataManager.Main.GraphDataUrlProperty.Value)
                {
                    DataManager.Main.GraphDataUrlProperty.Value = qr;
                    DataManager.Main.ScanningQRProperty.Value = false;
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }
}
