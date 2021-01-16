using System;
using UnityEngine;
using ZXing;

public class ScannerQR : MonoBehaviour
{
    public Camera cam;
    private BarcodeReader barCodeReader;
    private FrameCapturer pixelCapturer;
    private string lastScannedQr;

    private void Start()
    {
        barCodeReader = new BarcodeReader();
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
                string qr = data.Text;
                if (lastScannedQr != qr && DataManager.Main.ScanningQRProperty.Value)
                {
                    DataManager.Main.GraphDataUrlProperty.Value = qr;
                    lastScannedQr = qr;
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
        pixelCapturer.shouldCaptureOnNextFrame = true;
    }
}
