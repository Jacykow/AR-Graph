using UnityEngine;

public class GraphGenerator : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab, columnPrefab;

    public void ShowGraph(IGraphVisualizationData data)
    {
        switch (data.GraphType)
        {
            case GraphType.Balls:
                ShowBallGraph(data as BallGraph);
                break;
            case GraphType.Columns:
                ShowColumnGraph(data as ColumnGraph);
                break;
            default:
                Debug.LogWarning("Unsupported graph type!");
                break;
        }
    }

    private void ShowBallGraph(BallGraph graph)
    {
        foreach (var point in graph.BallPositions)
        {
            Instantiate(ballPrefab, point, Quaternion.identity, transform);
        }
    }

    private void ShowColumnGraph(ColumnGraph graph)
    {
        var largestDimension = Mathf.Max(graph.Values.GetLength(0), graph.Values.GetLength(1));
        var columnSize = new Vector3(1f / largestDimension, 1f, 1f / largestDimension);
        for (int x = 0; x < graph.Values.GetLength(0); x++)
        {
            for (int z = 0; z < graph.Values.GetLength(1); z++)
            {
                var columnPosition = new Vector3
                {
                    x = (float)(x + 1) / (graph.Values.GetLength(0) + 1),
                    y = graph.Values[x, z] / 2,
                    z = (float)(z + 1) / (graph.Values.GetLength(1) + 1)
                };
                columnSize.y = graph.Values[x, z];
                var column = Instantiate(columnPrefab, columnPosition, Quaternion.identity, transform);
                column.transform.localScale = columnSize;
            }
        }
    }
}
