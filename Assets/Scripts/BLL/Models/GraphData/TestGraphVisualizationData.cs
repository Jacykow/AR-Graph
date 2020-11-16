using System.Collections.Generic;
using UnityEngine;

public static class TestGraphVisualizationData
{
    public static ColumnGraphData Columns
    {
        get
        {
            var graph = new ColumnGraphData
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

    public static ColumnGraph2DData Columns2D
    {
        get
        {
            var graph = new ColumnGraph2DData
            {
                Values = new float[Random.Range(5, 15)]
            };
            for (int x = 0; x < graph.Values.Length; x++)
            {
                graph.Values[x] = Random.value;
            }
            return graph;
        }
    }

    public static BallGraphData Balls
    {
        get
        {
            var points = new List<Vector3>();
            for (int i = 0; i < 50; i++)
            {
                points.Add(new Vector3(Random.value, Random.value, Random.value));
            }

            return new BallGraphData
            {
                BallPositions = points.ToArray()
            };
        }
    }
}
