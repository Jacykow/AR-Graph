using System.Collections.Generic;
using UnityEngine;

public class GraphVisualizationData
{
    public Vector3[] points;
    public GraphType graphType;
    public int width;

    public static GraphVisualizationData TestBalls()
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

    public static GraphVisualizationData TestColumns()
    {
        var data = new GraphVisualizationData
        {
            graphType = GraphType.Columns
        };
        var points = new List<Vector3>();
        int width = Random.Range(5, 15);
        int depth = Random.Range(5, 15);
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                float xCoord = (x + 0.5f) / width;
                float zCoord = (z + 0.5f) / depth;
                points.Add(new Vector3(xCoord, Random.value, zCoord));
            }
        }
        data.width = width;
        data.points = points.ToArray();
        return data;
    }
}
