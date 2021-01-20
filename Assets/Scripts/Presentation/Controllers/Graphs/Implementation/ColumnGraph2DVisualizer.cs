using Assets.Scripts.BLL.Models.GraphData.Implementation;
using System.Linq;
using UnityEngine;

public class ColumnGraph2DVisualizer : BaseGraphVisualizer<ColumnGraph2DData>
{
    [SerializeField] private Renderer graphRenderer;

    protected override void Redraw(ColumnGraph2DData graphData)
    {
        var valuesArray = new float[100];
        graphData.Values.CopyTo(valuesArray, 0);
        graphRenderer.material.SetFloatArray("_Columns", valuesArray);
        // todo mati
        var colors = graphData.Values.Select(value => Color.HSVToRGB(value, 1, 1)).ToArray();
        var colorsArray = new Color[100];
        colors.CopyTo(colorsArray, 0);
        graphRenderer.material.SetColorArray("_Colors", colorsArray);
        graphRenderer.material.SetFloat("_ColumnAmount", graphData.Values.Length);
    }
}
