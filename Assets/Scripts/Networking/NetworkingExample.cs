using UniRx;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkingExample : MonoBehaviour
{
    private void Start()
    {
    }

    private void ExampleGET()
    {
        new UnityWebRequest
        {
            url = "https://argraph.azurewebsites.net/graph/1",
            method = "GET"
        }.ObserveRequestResult().Subscribe(text =>
        {
            Debug.Log(text);
        }).AddTo(this);
    }

    private void ExamplePOST()
    {
        DataManager.Main
            .SendGraph("{\"id\": 1, \"data\": \"przykladowe dane do grafu\"}")
            .Subscribe(text =>
        {
            Debug.Log(text);
        }).AddTo(this);
    }

    private void ExampleDELETE()
    {
        DataManager.Main
            .DeleteGraph("https://argraph.azurewebsites.net/graph/1")
            .Subscribe(text =>
        {
            Debug.Log(text);
        }).AddTo(this);
    }
}
