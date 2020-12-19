using System.Collections.Generic;
using System.Linq;
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
                Values = new float[Random.Range(5, 25)]
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

    public static SurfaceGraphData Surface
    {
        get
        {
            var graph = new SurfaceGraphData
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

    public static PieChart2DData Pie2D
    {
        get
        {
            var graph = new PieChart2DData
            {
                Values = new float[Random.Range(3, 10)]
            };
            for (int x = 0; x < graph.Values.Length; x++)
            {
                graph.Values[x] = Random.value;
            }
            return graph;
        }
    }

    public static UndirectedGraphData UndirectedGraph
    {
        get
        {
            var numberOfNodes = Random.Range(4, 25);
            var numberOfEdges = Random.Range(numberOfNodes, numberOfNodes * numberOfNodes / 4);
            var edges = new HashSet<(int, int)>();
            for (var i = 0; i < numberOfEdges; i++)
            {
                var first = Random.Range(0, numberOfNodes);
                var second = Random.Range(1, numberOfNodes);
                if (second == first) second = 0;
                edges.Add((first, second));
            }
            var graph = new UndirectedGraphData
            {
                NumberOfNodes = numberOfNodes,
                Edges = edges.ToArray()
            };
            return graph;
        }
    }
}
