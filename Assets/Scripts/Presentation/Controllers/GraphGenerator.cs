using UnityEngine;

public class GraphGenerator : MonoBehaviour
{
    public GameObject ballPrefab, columnPrefab;

    public void ShowGraph(GraphVisualizationData data)
    {
        if (data.graphType == GraphType.Balls)
        {
            foreach (var point in data.points)
            {
                Instantiate(ballPrefab, point, Quaternion.identity, transform);
            }
        }
        else if (data.graphType == GraphType.Columns)
        {
            var width = data.width;
            var height = data.points.Length / width;
            var largestDimension = Mathf.Max(width, height);
            var columnSize = new Vector3(1f / largestDimension, 0f, 1f / largestDimension);
            foreach (var point in data.points)
            {
                var columnPosition = point;
                columnPosition.y /= 2;
                var column = Instantiate(columnPrefab, columnPosition, Quaternion.identity, transform);
                columnSize.y = point.y;
                column.transform.localScale = columnSize;
            }
        }
    }
}
