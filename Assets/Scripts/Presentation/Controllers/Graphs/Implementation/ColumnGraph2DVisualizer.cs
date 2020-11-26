using UnityEngine;

public class ColumnGraph2DVisualizer : BaseGraphVisualizer<ColumnGraph2DData>
{
    [SerializeField] private Renderer graphRenderer;

    protected override void Redraw(ColumnGraph2DData graphData)
    {
        graphRenderer.material.SetFloat("_ColumnAmount", graphData.Values.Length);
        graphRenderer.material.SetFloatArray("_Columns", graphData.Values);
    }
}
