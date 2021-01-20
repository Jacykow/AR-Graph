using Assets.Scripts.BLL.Models.GraphData.Implementation;
using UnityEngine;

public class ColumnGraph2DVisualizer : BaseGraphVisualizer<ColumnGraph2DData>
{
    [SerializeField] private Renderer graphRenderer;

    protected override void Redraw(ColumnGraph2DData graphData)
    {
        graphRenderer.material.SetFloatArray("_Columns", graphData.Values);
        graphRenderer.material.SetFloat("_ColumnAmount", graphData.Values.Length);
    }
}
