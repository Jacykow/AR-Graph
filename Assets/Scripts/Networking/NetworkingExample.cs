using Newtonsoft.Json;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkingExample : MonoBehaviour
{
    private void Start()
    {
        ExamplePOST();
        //ExampleGET();
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

    private void ExamplePOST()
    {
        var randomdata = TestGraphVisualizationData.Pie2D;
        var container = new GraphDataContainer
        {
            visualizationData = randomdata
        };
        var jsonString = JsonConvert.SerializeObject(container);

        var graph = new BackendData(1, jsonString);
        var secondJsonString = JsonConvert.SerializeObject(graph);

        Debug.Log(secondJsonString);

        DataManager.Main
            .SendGraph(secondJsonString)
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
