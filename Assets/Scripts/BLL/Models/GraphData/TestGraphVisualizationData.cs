using Assets.Scripts.BLL.Models.GraphData.Implementation;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class TestGraphVisualizationData
{
    public static IGraphVisualizationData RandomData
    {
        get
        {
            var dataCollections = new IGraphVisualizationData[]
            {
                Columns,
                Columns2D,
                Balls,
                Surface,
                Pie2D,
                UndirectedGraph
            };
            return dataCollections[Random.Range(0, dataCollections.Length)];
        }
    }

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
            graph.MetaData = new BaseGraphMetaData
            {
                Title = "Column graph 3D",
                AxisNames = new[] { "", "", "" },
                Scale = Vector3.one,
                AxisLengths = Vector3.one
            };
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
            graph.MetaData = new BaseGraphMetaData
            {
                Title = "Column graph 2D",
                AxisNames = new[] { "", "", "" },
                Scale = Vector3.one,
                AxisLengths = Vector3.one
            };
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
            var graph = new BallGraphData
            {
                BallPositions = points.ToArray()
            };
            graph.MetaData = new BaseGraphMetaData
            {
                Title = "Ball graph",
                AxisNames = new[] { "(1, 0, 0)", "(0, 1, 0)", "(0, 0, 1)" },
                Scale = Vector3.one,
                AxisLengths = Vector3.one
            };
            return graph;
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
            graph.MetaData = new BaseGraphMetaData
            {
                Title = "Surface graph",
                AxisNames = new[] { "x", "y", "z" },
                Scale = new Vector3(1.2f, 0.08f, 1.5f),
                AxisLengths = new Vector3(1.2f, 0.8f, 1.5f)
            };
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
            graph.MetaData = new BaseGraphMetaData
            {
                Title = "Pie chart 2D",
                AxisNames = new[] { "", "", "" },
                Scale = Vector3.one,
                AxisLengths = Vector3.one
            };
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
            graph.MetaData = new BaseGraphMetaData
            {
                Title = "Undirected graph",
                AxisNames = new[] { "", "", "" },
                Scale = Vector3.one,
                AxisLengths = Vector3.one
            };
            return graph;
        }
    }
}
