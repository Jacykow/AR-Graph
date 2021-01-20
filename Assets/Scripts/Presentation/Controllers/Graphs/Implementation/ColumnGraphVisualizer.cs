using Assets.Scripts.BLL.Models.GraphData.Implementation;
using System.Collections.Generic;
using UnityEngine;

public class ColumnGraphVisualizer : BaseGraphVisualizer<ColumnGraphData>
{
    [SerializeField] private GameObject columnPrefab;

    private readonly List<GameObject> columns = new List<GameObject>();

    protected override void Redraw(ColumnGraphData graphData)
    {
        foreach (var column in columns)
        {
            Destroy(column);
        }
        columns.Clear();

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
                // todo mati
                var color = Color.HSVToRGB(graphData.Values[x, z], 1, 1);
                var column = Instantiate(columnPrefab, transform.position, transform.rotation, transform);
                column.transform.localPosition = columnPosition;
                column.transform.localScale = columnSize;
                column.GetComponent<Renderer>().material.color = color;
                columns.Add(column);
            }
        }
    }
}
