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
                //Values = new float[Random.Range(5, 15), Random.Range(5, 15)]
                Values = new float[5, 3]
            };
            for (int x = 0; x < graph.Values.GetLength(0); x++)
            {
                for (int z = 0; z < graph.Values.GetLength(1); z++)
                {
                    graph.Values[x, z] = Random.value;
                }
            }
            graph.MetaData = new ColumnGraphMetaData
            {
                Title = "Column graph 3D",
                Scale = Vector3.one,
                AxisLengths = Vector3.one,
                LabelsX = new[] { "2017", "2018", "2019", "2020" },
                LabelsZ = new[] { "Wiosna", "Lato", "Jesień", "Zima" },
                Colors = new[] { new UnityReplacement.Color(Color.red), new UnityReplacement.Color(Color.green), new UnityReplacement.Color(Color.blue) }
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
            graph.MetaData = new ColumnGraph2DMetaData
            {
                Title = "Column graph 2D",
                Scale = Vector3.one,
                AxisLengths = Vector3.one,
                LabelsX = new[] { "USA", "Rosja", "Chiny", "Indie" },
                Colors = new[] { new UnityReplacement.Color(Color.blue), new UnityReplacement.Color(Color.yellow) }
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
            graph.MetaData = new BallGraphMetaData
            {
                Title = "Ball graph",
                AxisNames = new[] { "(1, 0, 0)", "(0, 1, 0)", "(0, 0, 1)" },
                Scale = Vector3.one,
                AxisLengths = Vector3.one,
                Colors = new[] { new UnityReplacement.Color(Color.red), new UnityReplacement.Color(Color.green), new UnityReplacement.Color(Color.blue) }
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
                Values = new float[30, 30]
            };
            float randomX = Random.Range(-1f, 1f);
            for (int x = 0; x < graph.Values.GetLength(0); x++)
            {
                for (int z = 0; z < graph.Values.GetLength(1); z++)
                {
                    float graphX = (float)x / (graph.Values.GetLength(0) - 1);
                    float graphZ = (float)z / (graph.Values.GetLength(1) - 1);
                    graphX = 2 * graphX - 1 + randomX;
                    graphX *= graphX;
                    graphZ = 2 * (1 - graphZ) + 1;
                    graph.Values[x, z] = Mathf.Clamp((graphX * graphX + graphZ * graphZ - 2 * graphX * graphZ) * 0.1f, 0f, 1f);
                }
            }
            graph.MetaData = new SurfaceGraphMetaData
            {
                Title = "Surface graph",
                AxisNames = new[] { "x", "y", "z" },
                Scale = new Vector3(1f, 1f, 1f),
                AxisLengths = new Vector3(1f, 1f, 1f),
                Color = new UnityReplacement.Color(Color.cyan)
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
            graph.MetaData = new PieChart2DMetaData
            {
                Title = "Pie chart 2D",
                Scale = Vector3.one,
                AxisLengths = Vector3.one,
                Colors = new[] { new UnityReplacement.Color(Color.red), new UnityReplacement.Color(Color.green), new UnityReplacement.Color(Color.blue) }
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
            graph.MetaData = new UndirectedGraphMetaData
            {
                Title = "Undirected graph",
                Scale = Vector3.one,
                AxisLengths = Vector3.one,
                NodeColors = new[] { new UnityReplacement.Color(Color.gray) },
                EdgeColor = new UnityReplacement.Color(Color.red)
            };
            return graph;
        }
    }
}
