using UnityEngine;

namespace Assets.Scripts.BLL.Models.GraphData.Implementation
{
    public class BallGraphData : IGraphVisualizationData
    {
        public Vector3[] BallPositions { get; set; }
        public IGraphMetaData MetaData { get; set; }
    }
}