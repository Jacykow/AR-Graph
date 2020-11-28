using UnityEngine;

public class ColumnGraphVisualizer : BaseGraphVisualizer<ColumnGraphData>
{
    [SerializeField] private GameObject columnPrefab;

    protected override void Redraw(ColumnGraphData graphData)
    {
        var largestDimension = Mathf.Max(graphData.Values.GetLength(0), graphData.Values.GetLength(1));
        var columnSize = new Vector3(1f / largestDimension, 1f, 1f / largestDimension);
        for (int x = 0; x < graphData.Values.GetLength(0); x++)
        {
            for (int z = 0; z < graphData.Values.GetLength(1); z++)
            {
                var columnPosition = new Vector3
                {
                    x = (float)(x + 1) / (graphData.Values.GetLength(0) + 1),
                    y = graphData.Values[x, z] / 2,
                    z = (float)(z + 1) / (graphData.Values.GetLength(1) + 1)
                };
                columnSize.y = graphData.Values[x, z];
                var column = Instantiate(columnPrefab, columnPosition, Quaternion.identity, transform);
                column.transform.localScale = columnSize;
            }
        }
    }
}
