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
                Values = new[,]
                {
                    {0.3232F, 0.4272F, 0.5068F},
                    {0.5892F, 0.6612F, 0.5900F},
                    {0.1688F, 0.1744F, 0.2212F},
                    {0.4656F, 0.5072F, 0.4904F},
                    {0.2068F, 0.4644F, 0.1052F}
                }
            };
            graph.MetaData = new ColumnGraphMetaData
            {
                Title = "Accuracy",
                Scale = Vector3.one,
                AxisLengths = new Vector3(1f, 1f, 1f),
                LabelsX = new[] { "binary", "hash", "ordinal", "onehot", "word2vec" },
                LabelsZ = new[] { "CNN", "LSTM", "MLP" },
                Colors = new[] { Color.red, Color.green, Color.blue }
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
                Values = new[]
                {
                    0f, 0.82f, 0.7f, 0f, 0f, 0.94f, 0.5f, 0f, 0f, 0.97f, 0.9f, 0f, 0f, 0.62f, 0.2f, 0f, 0f, 0.6f, 0.8f, 0f
                }
            };
            graph.MetaData = new ColumnGraph2DMetaData
            {
                Title = "Computation time",
                Scale = Vector3.one,
                AxisLengths = Vector3.one,
                LabelsX = new[] { "50", "100", "150", "200", "250" },
                Colors = new[] { Color.clear, Color.blue, Color.yellow, Color.clear }
            };
            return graph;
        }
    }

    public static BallGraphData Balls
    {
        get
        {
            var points = new List<Vector3>
            {
                new Vector3(5.1f, 3.5f, 1.4f),
                new Vector3(7.0f, 3.2f, 4.7f),
                new Vector3(6.3f, 3.3f, 6.0f),
                new Vector3(4.9f, 3.0f, 1.4f),
                new Vector3(6.4f, 3.2f, 4.5f),
                new Vector3(5.8f, 2.7f, 5.1f),
                new Vector3(4.7f, 3.2f, 1.3f),
                new Vector3(6.9f, 3.1f, 4.9f),
                new Vector3(7.1f, 3.0f, 5.9f),
                new Vector3(4.6f, 3.1f, 1.5f),
                new Vector3(5.5f, 2.3f, 4.0f),
                new Vector3(6.3f, 2.9f, 5.6f),
                new Vector3(5.0f, 3.6f, 1.4f),
                new Vector3(6.5f, 2.8f, 4.6f),
                new Vector3(6.5f, 3.0f, 5.8f),
                new Vector3(5.4f, 3.9f, 1.7f),
                new Vector3(5.7f, 2.8f, 4.5f),
                new Vector3(7.6f, 3.0f, 6.6f),
                new Vector3(4.6f, 3.4f, 1.4f),
                new Vector3(6.3f, 3.3f, 4.7f),
                new Vector3(4.9f, 2.5f, 4.5f),
                new Vector3(5.0f, 3.4f, 1.5f),
                new Vector3(4.9f, 2.4f, 3.3f),
                new Vector3(7.3f, 2.9f, 6.3f),
                new Vector3(4.4f, 2.9f, 1.4f),
                new Vector3(6.6f, 2.9f, 4.6f),
                new Vector3(6.7f, 2.5f, 5.8f),
                new Vector3(4.9f, 3.1f, 1.5f),
                new Vector3(5.2f, 2.7f, 3.9f),
                new Vector3(7.2f, 3.6f, 6.1f),
                new Vector3(5.4f, 3.7f, 1.5f),
                new Vector3(5.0f, 2.0f, 3.5f),
                new Vector3(6.5f, 3.2f, 5.1f),
                new Vector3(4.8f, 3.4f, 1.6f),
                new Vector3(5.9f, 3.0f, 4.2f),
                new Vector3(6.4f, 2.7f, 5.3f),
                new Vector3(4.8f, 3.0f, 1.4f),
                new Vector3(6.0f, 2.2f, 4.0f),
                new Vector3(6.8f, 3.0f, 5.5f),
                new Vector3(4.3f, 3.0f, 1.1f),
                new Vector3(6.1f, 2.9f, 4.7f),
                new Vector3(5.7f, 2.5f, 5.0f),
                new Vector3(5.8f, 4.0f, 1.2f),
                new Vector3(5.6f, 2.9f, 3.6f),
                new Vector3(5.8f, 2.8f, 5.1f),
                new Vector3(5.7f, 4.4f, 1.5f),
                new Vector3(6.7f, 3.1f, 4.4f),
                new Vector3(6.4f, 3.2f, 5.3f),
                new Vector3(5.4f, 3.9f, 1.3f),
                new Vector3(5.6f, 3.0f, 4.5f),
                new Vector3(6.5f, 3.0f, 5.5f),
                new Vector3(5.1f, 3.5f, 1.4f),
                new Vector3(5.8f, 2.7f, 4.1f),
                new Vector3(7.7f, 3.8f, 6.7f),
                new Vector3(5.7f, 3.8f, 1.7f),
                new Vector3(6.2f, 2.2f, 4.5f),
                new Vector3(7.7f, 2.6f, 6.9f),
                new Vector3(5.1f, 3.8f, 1.5f),
                new Vector3(5.6f, 2.5f, 3.9f),
                new Vector3(6.0f, 2.2f, 5.0f),
                new Vector3(5.4f, 3.4f, 1.7f),
                new Vector3(5.9f, 3.2f, 4.8f),
                new Vector3(6.9f, 3.2f, 5.7f),
                new Vector3(5.1f, 3.7f, 1.5f),
                new Vector3(6.1f, 2.8f, 4.0f),
                new Vector3(5.6f, 2.8f, 4.9f),
                new Vector3(4.6f, 3.6f, 1.0f),
                new Vector3(6.3f, 2.5f, 4.9f),
                new Vector3(7.7f, 2.8f, 6.7f),
                new Vector3(5.1f, 3.3f, 1.7f),
                new Vector3(6.1f, 2.8f, 4.7f),
                new Vector3(6.3f, 2.7f, 4.9f),
                new Vector3(4.8f, 3.4f, 1.9f),
                new Vector3(6.4f, 2.9f, 4.3f),
                new Vector3(6.7f, 3.3f, 5.7f),
                new Vector3(5.0f, 3.0f, 1.6f),
                new Vector3(6.6f, 3.0f, 4.4f),
                new Vector3(7.2f, 3.2f, 6.0f),
                new Vector3(5.0f, 3.4f, 1.6f),
                new Vector3(6.8f, 2.8f, 4.8f),
                new Vector3(6.2f, 2.8f, 4.8f),
                new Vector3(5.2f, 3.5f, 1.5f),
                new Vector3(6.7f, 3.0f, 5.0f),
                new Vector3(6.1f, 3.0f, 4.9f),
                new Vector3(5.2f, 3.4f, 1.4f),
                new Vector3(6.0f, 2.9f, 4.5f),
                new Vector3(6.4f, 2.8f, 5.6f),
                new Vector3(4.7f, 3.2f, 1.6f),
                new Vector3(5.7f, 2.6f, 3.5f),
                new Vector3(7.2f, 3.0f, 5.8f),
                new Vector3(4.8f, 3.1f, 1.6f),
                new Vector3(5.5f, 2.4f, 3.8f),
                new Vector3(7.4f, 2.8f, 6.1f),
                new Vector3(5.4f, 3.4f, 1.5f),
                new Vector3(5.5f, 2.4f, 3.7f),
                new Vector3(7.9f, 3.8f, 6.4f),
                new Vector3(5.2f, 4.1f, 1.5f),
                new Vector3(5.8f, 2.7f, 3.9f),
                new Vector3(6.4f, 2.8f, 5.6f),
                new Vector3(5.5f, 4.2f, 1.4f),
                new Vector3(6.0f, 2.7f, 5.1f),
                new Vector3(6.3f, 2.8f, 5.1f),
                new Vector3(4.9f, 3.1f, 1.5f),
                new Vector3(5.4f, 3.0f, 4.5f),
                new Vector3(6.1f, 2.6f, 5.6f),
                new Vector3(5.0f, 3.2f, 1.2f),
                new Vector3(6.0f, 3.4f, 4.5f),
                new Vector3(7.7f, 3.0f, 6.1f),
                new Vector3(5.5f, 3.5f, 1.3f),
                new Vector3(6.7f, 3.1f, 4.7f),
                new Vector3(6.3f, 3.4f, 5.6f),
                new Vector3(4.9f, 3.6f, 1.4f),
                new Vector3(6.3f, 2.3f, 4.4f),
                new Vector3(6.4f, 3.1f, 5.5f),
                new Vector3(4.4f, 3.0f, 1.3f),
                new Vector3(5.6f, 3.0f, 4.1f),
                new Vector3(6.0f, 3.0f, 4.8f),
                new Vector3(5.1f, 3.4f, 1.5f),
                new Vector3(5.5f, 2.5f, 4.0f),
                new Vector3(6.9f, 3.1f, 5.4f),
                new Vector3(5.0f, 3.5f, 1.3f),
                new Vector3(5.5f, 2.6f, 4.4f),
                new Vector3(6.7f, 3.1f, 5.6f),
                new Vector3(4.5f, 2.3f, 1.3f),
                new Vector3(6.1f, 3.0f, 4.6f),
                new Vector3(6.9f, 3.1f, 5.1f),
                new Vector3(4.4f, 3.2f, 1.3f),
                new Vector3(5.8f, 2.6f, 4.0f),
                new Vector3(5.8f, 2.7f, 5.1f),
                new Vector3(5.0f, 3.5f, 1.6f),
                new Vector3(5.0f, 2.3f, 3.3f),
                new Vector3(6.8f, 3.2f, 5.9f),
                new Vector3(5.1f, 3.8f, 1.9f),
                new Vector3(5.6f, 2.7f, 4.2f),
                new Vector3(6.7f, 3.3f, 5.7f),
                new Vector3(4.8f, 3.0f, 1.4f),
                new Vector3(5.7f, 3.0f, 4.2f),
                new Vector3(6.7f, 3.0f, 5.2f),
                new Vector3(5.1f, 3.8f, 1.6f),
                new Vector3(5.7f, 2.9f, 4.2f),
                new Vector3(6.3f, 2.5f, 5.0f),
                new Vector3(4.6f, 3.2f, 1.4f),
                new Vector3(6.2f, 2.9f, 4.3f),
                new Vector3(6.5f, 3.0f, 5.2f),
                new Vector3(5.3f, 3.7f, 1.5f),
                new Vector3(5.1f, 2.5f, 3.0f),
                new Vector3(6.2f, 3.4f, 5.4f),
                new Vector3(5.0f, 3.3f, 1.4f),
                new Vector3(5.7f, 2.8f, 4.1f),
                new Vector3(5.9f, 3.0f, 5.1f)
            };
            var graph = new BallGraphData
            {
                BallPositions = points.ToArray()
            };
            graph.MetaData = new BallGraphMetaData
            {
                Title = "Iris dataset",
                AxisNames = new[] { "Sepal length", "Sepal width", "Petal length" },
                Scale = Vector3.one / 10f,
                AxisLengths = new Vector3(1f, 0.6f, 1f),
                Colors = new[] { Color.red, Color.green, Color.blue }
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
                Color = Color.cyan
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
                Values = new[] { 62f, 46f, 38f, 31f, 27f, 14f, 14f }
            };
            graph.MetaData = new PieChart2DMetaData
            {
                Title = "Pie chart 2D",
                Scale = Vector3.one,
                AxisLengths = Vector3.one,
                Colors = new[] { Color.yellow, Color.red, Color.cyan, Color.green, Color.magenta, Color.blue, Color.gray }
            };
            return graph;
        }
    }

    public static UndirectedGraphData UndirectedGraph
    {
        get
        {
            var numberOfNodes = 16;
            var edges = new HashSet<(int, int)>();
            for (var i = 0; i < numberOfNodes; i++)
            {
                for (var j = 1; j < 3; j++)
                {
                    var second = (i + j) % numberOfNodes;
                    edges.Add((i, second));
                }
            }
            var graph = new UndirectedGraphData
            {
                NumberOfNodes = numberOfNodes,
                Edges = edges.ToArray()
            };
            graph.MetaData = new UndirectedGraphMetaData
            {
                Title = "Instance graph",
                Scale = Vector3.one,
                AxisLengths = Vector3.one,
                NodeColors = new[] { Color.gray },
                EdgeColor = Color.blue
            };
            return graph;
        }
    }
}
