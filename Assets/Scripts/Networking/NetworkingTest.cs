﻿using UniRx;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkingTest : MonoBehaviour
{
    private void Start()
    {
        new UnityWebRequest
        {
            url = "https://www.google.pl/",
            method = "GET"
        }.ObserveRequestResult().Subscribe(text =>
        {
            Debug.Log(text);
        }).AddTo(this);
    }
}
