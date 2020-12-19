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

    public ReactiveProperty<GraphData> GraphDataProperty { get; } = new ReactiveProperty<GraphData>();

    public IReactiveProperty<VisualisationTypeData> VisualisationTypeDataProperty { get; } = new ReactiveProperty<VisualisationTypeData>();
}
