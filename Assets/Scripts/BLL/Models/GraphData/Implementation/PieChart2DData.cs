namespace Assets.Scripts.BLL.Models.GraphData.Implementation
{
    public class PieChart2DData : IGraphVisualizationData
    {
        public float[] Values { get; set; }
        public IGraphMetaData MetaData { get; set; }
    }
}