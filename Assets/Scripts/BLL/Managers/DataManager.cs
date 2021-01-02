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

    public IReactiveProperty<VisualisationType> VisualisationTypeProperty { get; } = new ReactiveProperty<VisualisationType>(VisualisationType.Space3D);

    public ReactiveProperty<ExampleGraphData> GraphDataProperty { get; } = new ReactiveProperty<ExampleGraphData>();
}
