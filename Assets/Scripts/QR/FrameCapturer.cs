using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameCapturer : MonoBehaviour
{

    // Script Inputs
    public bool m_shouldCaptureOnNextFrame = false;
    public Color32[] m_lastCapturedColors;
    // Privates
    Texture2D m_centerPixTex;

    void Start()
    {
        Resolution currentResolution = Screen.currentResolution;
        m_centerPixTex = new Texture2D(currentResolution.width, currentResolution.height, TextureFormat.RGBA32, false);
    }

    void OnPostRender()
    {

        if (m_shouldCaptureOnNextFrame)
        {
            Resolution res = Screen.currentResolution;
            m_lastCapturedColors = GetRenderedColors();
            m_shouldCaptureOnNextFrame = false;
        }
    }

    // Helpers
    Color32[] GetRenderedColors()
    {
        Resolution currentResolution = Screen.currentResolution;
        m_centerPixTex.ReadPixels(new Rect(0, 0, currentResolution.width, currentResolution.height), 0, 0);
        m_centerPixTex.Apply();

        return m_centerPixTex.GetPixels32();
    }
    
}
