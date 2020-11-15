using System.Collections.Generic;
using UnityEngine;

public static class TestGraphVisualizationData
{
    public static ColumnGraph TestColumns
    {
        get
        {
            var graph = new ColumnGraph
            {
                Values = new float[Random.Range(5, 15), Random.Range(5, 15)]
            };
            for (int x = 0; x < graph.Values.GetLength(0); x++)
            {
                for (int z = 0; z < graph.Values.GetLength(1); z++)
                {
                    graph.Values[x, z] = Random.value;
                }
            }
            return graph;
        }
    }

    public static BallGraph TestBalls
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
