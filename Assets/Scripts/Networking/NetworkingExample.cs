using Assets.Scripts.BLL.Managers;
using Assets.Scripts.BLL.Models.GraphData;
using Assets.Scripts.Networking;
using Newtonsoft.Json;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkingExample : MonoBehaviour
{
    private void Start()
    {
        DataManager.Main.SendGraph(1, TestGraphVisualizationData.UndirectedGraph).Subscribe().AddTo(this);
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
            var deserialized = JsonConvert.DeserializeObject<BackendData>(text);
            var desContainer = JsonConvert.DeserializeObject<GraphDataContainer>(deserialized.data);
            Debug.Log(desContainer);
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