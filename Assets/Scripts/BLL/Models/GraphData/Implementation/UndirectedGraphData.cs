﻿namespace Assets.Scripts.BLL.Models.GraphData.Implementation
{
    public class UndirectedGraphData : IGraphVisualizationData
    {
        public int NumberOfNodes { get; set; }
        public (int, int)[] Edges { get; set; }
        public IGraphMetaData MetaData { get; set; }
    }
}