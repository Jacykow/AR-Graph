using System.Collections.Generic;
using UnityEngine;

public class GraphVisualizationData
{
    public Vector3[] points;
    public GraphType graphType;

    public static GraphVisualizationData TestData()
    {
        var data = new GraphVisualizationData
        {
            graphType = GraphType.Balls
        };
        var points = new List<Vector3>();
        for (int i = 0; i < 50; i++)
        {
            points.Add(new Vector3(Random.value, Random.value, Random.value));
        }
        data.points = points.ToArray();
        return data;
    }
}
