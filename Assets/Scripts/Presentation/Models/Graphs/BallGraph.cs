using UnityEngine;

public class BallGraph : IGraphVisualizationData
{
    public GraphType GraphType => GraphType.Balls;

    public Vector3[] BallPositions { get; set; }
}
