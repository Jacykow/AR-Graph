using Assets.Scripts.BLL.Models.GraphData.Implementation;
using System.Linq;
using UnityEngine;

public class ColumnGraph2DVisualizer : BaseGraphVisualizer<ColumnGraph2DData>
{
    [SerializeField] private Renderer graphRenderer;

    protected override void Redraw(ColumnGraph2DData graphData)
    {
        graphRenderer.material.SetFloatArray("_Columns", graphData.Values);
        // todo mati
        var colors = graphData.Values.Select(value => Color.HSVToRGB(value, 1, 1)).ToArray();
        graphRenderer.material.SetColorArray("_Colors", colors);
        graphRenderer.material.SetFloat("_ColumnAmount", graphData.Values.Length);
    }
}
