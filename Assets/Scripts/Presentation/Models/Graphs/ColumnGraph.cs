using UnityEngine;

public class ColumnGraph : IGraphVisualizationData
{
    public GraphType GraphType => GraphType.Columns;

    public float[,] Values { get; set; }

    public static ColumnGraph Test
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
}
