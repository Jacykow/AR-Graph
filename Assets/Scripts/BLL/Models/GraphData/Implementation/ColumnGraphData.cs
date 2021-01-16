namespace Assets.Scripts.BLL.Models.GraphData.Implementation
{
    public class ColumnGraphData : IGraphVisualizationData
    {
        public float[,] Values { get; set; }
        public IGraphMetaData MetaData { get; set; }
    }
}