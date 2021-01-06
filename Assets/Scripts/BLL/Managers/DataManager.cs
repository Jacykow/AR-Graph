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

    private IReadOnlyReactiveProperty<IGraphVisualizationData> _graphDataProperty;

    public IReactiveProperty<string> GraphDataUrlProperty { get; } =
        new ReactiveProperty<string>("https://argraph.azurewebsites.net/graph/11");

    public IReactiveProperty<VisualisationType> VisualisationTypeProperty { get; } =
        new ReactiveProperty<VisualisationType>(VisualisationType.Space3D);

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
                    .SelectMany(graphDataJson =>
                    {
                        // todo Grzegorz

                        return Observable.Return(TestGraphVisualizationData.RandomData);
                    })
                    .ToReadOnlyReactiveProperty();
            }
            return _graphDataProperty;
        }
    }


    public void SendGraph(string body)
    {
        var request = new UnityWebRequest
        {
            url = "https://argraph.azurewebsites.net/graph",
            method = "POST"
        };

        byte[] data = System.Text.Encoding.UTF8.GetBytes(body);
        UploadHandlerRaw upHandler = new UploadHandlerRaw(data);
        upHandler.contentType = "application/json";
        request.uploadHandler = upHandler;

        var response = request.ObserveRequestResult();
    }

    public void DeleteGraph(string url)
    {
        var request = new UnityWebRequest
        {
            url = url,
            method = "DELETE"
        };

        var response = request.ObserveRequestResult();
    }
}
