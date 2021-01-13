﻿using Newtonsoft.Json;
using System;
using UniRx;
using UnityEngine.Networking;

public class DataManager
{
    private static DataManager _main;
    public static DataManager Main
    {
        get
        {
            if (_main == null)
            {
                _main = new DataManager();
            }
            return _main;
        }
    }

    private Subject<IGraphVisualizationData> _randomGraphSubject = new Subject<IGraphVisualizationData>();

    private IReadOnlyReactiveProperty<IGraphVisualizationData> _graphDataProperty;

    public IReactiveProperty<string> GraphDataUrlProperty { get; } =
        new ReactiveProperty<string>(null);

    public IReactiveProperty<VisualisationType> VisualisationTypeProperty { get; } =
        new ReactiveProperty<VisualisationType>(VisualisationType.ArOnPaperCard);

    public IReadOnlyReactiveProperty<IGraphVisualizationData> GraphDataProperty
    {
        get
        {
            if (_graphDataProperty == null)
            {
                _graphDataProperty = GraphDataUrlProperty
                    .SelectMany(url =>
                    {
                        return new UnityWebRequest
                        {
                            url = url,
                            method = "GET"
                        }.ObserveRequestResult();
                    })
                    .Select(graphDataJson =>
                    {
                        var deserializedBackendData = JsonConvert.DeserializeObject<BackendData>(graphDataJson);
                        if (deserializedBackendData == null)
                        {
                            return TestGraphVisualizationData.RandomData;
                        }
                        var deserializedGraphData = JsonConvert.DeserializeObject<GraphDataContainer>(deserializedBackendData.data);
                        return deserializedGraphData.visualizationData;
                    })
                    .Merge(_randomGraphSubject)
                    .ToReadOnlyReactiveProperty();
            }
            return _graphDataProperty;
        }
    }

    public IObservable<string> SendGraph(int id, IGraphVisualizationData graphData)
    {
        var container = new GraphDataContainer
        {
            visualizationData = graphData
        };
        var containerJson = JsonConvert.SerializeObject(container);

        var graph = new BackendData(id, containerJson);
        var graphJson = JsonConvert.SerializeObject(graph);

        return SendGraph(graphJson);
    }

    public IObservable<string> SendGraph(string body)
    {
        var request = new UnityWebRequest
        {
            url = "https://argraph.azurewebsites.net/graph",
            method = "POST"
        };

        byte[] data = System.Text.Encoding.UTF8.GetBytes(body);
        UploadHandlerRaw uploadHandlerRaw = new UploadHandlerRaw(data);
        uploadHandlerRaw.contentType = "application/json";
        request.uploadHandler = uploadHandlerRaw;

        return request.ObserveRequestResult();
    }

    public IObservable<string> DeleteGraph(string url)
    {
        var request = new UnityWebRequest
        {
            url = url,
            method = "DELETE"
        };

        return request.ObserveRequestResult();
    }

    public void LoadGraph(IGraphVisualizationData graph)
    {
        _randomGraphSubject.OnNext(graph);
    }
}
