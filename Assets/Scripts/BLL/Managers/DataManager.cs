using UniRx;

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
        new ReactiveProperty<string>(null);

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
                        // todo Ewelina
                        return Observable.Return("graphDataJson");
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
}
