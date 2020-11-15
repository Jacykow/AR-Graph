public class ColumnGraph : IGraphVisualizationData
{
    public GraphType GraphType => GraphType.Columns;

    public float[,] Values { get; set; }
}
