using UnityEngine;

public class FrameCapturer : MonoBehaviour
{
    public bool shouldCaptureOnNextFrame = true;
    public Color32[] lastCapturedColors;
    private Texture2D centerPixTex;

    private void Start()
    {
        Resolution currentResolution = Screen.currentResolution;
        centerPixTex = new Texture2D(currentResolution.width, currentResolution.height, TextureFormat.RGBA32, false);
    }

    private void OnPostRender()
    {
        if (shouldCaptureOnNextFrame)
        {
            Resolution res = Screen.currentResolution;
            lastCapturedColors = GetRenderedColors();
            shouldCaptureOnNextFrame = false;
        }
    }

   private Color32[] GetRenderedColors()
    {
        Resolution currentResolution = Screen.currentResolution;
        centerPixTex.ReadPixels(new Rect(0, 0, currentResolution.width, currentResolution.height), 0, 0);
        centerPixTex.Apply();
        return centerPixTex.GetPixels32();
    }
}
