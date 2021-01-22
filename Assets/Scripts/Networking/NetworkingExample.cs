using Assets.Scripts.BLL.Managers;
using Assets.Scripts.Networking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkingExample : MonoBehaviour
{
    private void Start()
    {
        SendAndGet(TestGraphVisualizationData.Balls, TestGraphVisualizationData.Columns2D, TestGraphVisualizationData.Surface)
            .Subscribe(graphs =>
            {
                foreach (var graph in graphs)
                {
                    Debug.Log(graph);
                }
            }).AddTo(this);
    }

    private IObservable<IEnumerable<IGraphVisualizationData>> SendAndGet(params IGraphVisualizationData[] graphs)
    {
        return SendGraphs(graphs).SelectMany(GetGraphs(Enumerable.Range(1, graphs.Length).ToArray()));
    }

    private IObservable<Unit> SendGraphs(params IGraphVisualizationData[] graphs)
    {
        var graphSendRequests = new List<IObservable<string>>();
        for (int x = 0; x < graphs.Length; x++)
        {
            int id = x + 1;
            graphSendRequests.Add(DataManager.Main.SendGraph(id, graphs[x]));
        }
        return Observable.WhenAll(graphSendRequests).Select(graphSendResponses =>
        {
            foreach (var response in graphSendResponses)
            {
                //Debug.Log(response);
            }
            return Unit.Default;
        });
    }

    private IObservable<IEnumerable<IGraphVisualizationData>> GetGraphs(params int[] ids)
    {
        return ids.Select(id => GetGraph(id)).WhenAll();
    }

    private IObservable<IGraphVisualizationData> GetGraph(int id)
    {
        return new UnityWebRequest
        {
            url = "https://argraph.azurewebsites.net/graph/" + id,
            method = "GET"
        }.ObserveRequestResult().Select(graphDataJson =>
        {
            var deserializedBackendData = JsonConvert.DeserializeObject<BackendData>(graphDataJson, DataManager.JsonSettings);
            var deserializedGraphData = JsonConvert.DeserializeObject<GraphDataContainer>(deserializedBackendData.data, DataManager.JsonSettings);
            return deserializedGraphData.visualizationData;
        });
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