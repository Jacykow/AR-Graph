using System.Collections.Generic;
using UnityEngine;

public class BallGraph : IGraphVisualizationData
{
    public GraphType GraphType => GraphType.Balls;

    public Vector3[] BallPositions { get; set; }

    public static BallGraph Test
    {
        get
        {
            var points = new List<Vector3>();
            for (int i = 0; i < 50; i++)
            {
                points.Add(new Vector3(Random.value, Random.value, Random.value));
            }

            return new BallGraph
            {
                BallPositions = points.ToArray()
            };
        }
    }
}
