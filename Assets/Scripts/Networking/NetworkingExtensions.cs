using System;
using UniRx;
using UnityEngine.Networking;

public static class NetworkingExtensions
{
    public static IObservable<string> ObserveRequestResult(this UnityWebRequest request)
    {
        if (request.downloadHandler == null)
        {
            request.downloadHandler = new DownloadHandlerBuffer();
        }
        return request.SendWebRequest().AsObservable().Select(_ =>
        {
            return request.downloadHandler.text;
        });
    }
}
