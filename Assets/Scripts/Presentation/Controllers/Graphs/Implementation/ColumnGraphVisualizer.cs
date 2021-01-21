using Assets.Scripts.BLL.Models.GraphData.Implementation;
using System.Collections.Generic;
using UnityEngine;

public class ColumnGraphVisualizer : BaseGraphVisualizer<ColumnGraphData>
{
    [SerializeField] private GameObject columnPrefab;
    [SerializeField] private Color defaultColor = new Color(1f, 1f, 1f);

    private readonly List<GameObject> columns = new List<GameObject>();

    protected override void Redraw(ColumnGraphData graphData)
    {
        foreach (var column in columns)
        {
            Destroy(column);
        }
        columns.Clear();

        var metaData = graphData.MetaData as ColumnGraphMetaData;
        var colors = metaData?.Colors ?? new[] { defaultColor };
        var largestDimension = Mathf.Max(graphData.Values.GetLength(0), graphData.Values.GetLength(1));
        var columnSize = new Vector3(1f / largestDimension, 1f, 1f / largestDimension) * 0.75f;
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
                var columnNumber = graphData.Values.GetLength(1) * x + z;
                var color = colors[columnNumber % colors.Length];
                var column = Instantiate(columnPrefab, transform.position, transform.rotation, transform);
                column.transform.localPosition = columnPosition;
                column.transform.localScale = columnSize;
                column.GetComponent<Renderer>().material.color = color;
                columns.Add(column);
            }
        }
    }
}
