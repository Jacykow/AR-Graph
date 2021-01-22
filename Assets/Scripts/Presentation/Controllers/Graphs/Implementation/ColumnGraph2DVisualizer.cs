using Assets.Scripts.BLL.Models.GraphData.Implementation;
using System.Linq;
using UnityEngine;

public class ColumnGraph2DVisualizer : BaseGraphVisualizer<ColumnGraph2DData>
{
    [SerializeField] private Renderer graphRenderer;
    [SerializeField] private Color defaultColor = Color.white;

    private const int MaxValues = 100;

    protected override void Redraw(ColumnGraph2DData graphData)
    {
        var valuesArray = new float[MaxValues];
        graphData.Values.CopyTo(valuesArray, 0);
        graphRenderer.material.SetFloatArray("_Columns", valuesArray);
        var metaData = graphData.MetaData as ColumnGraph2DMetaData;
        var colors = metaData?.Colors.Select(color => color.ToUnityColor()).ToArray() ?? new[] { defaultColor };
        var colorsArray = new Color[MaxValues];
        for (var i = 0; i < graphData.Values.Length; i += colors.Length)
        {
            colors.CopyTo(colorsArray, i);
        }
        colors.CopyTo(colorsArray, 0);
        graphRenderer.material.SetColorArray("_Colors", colorsArray);
        graphRenderer.material.SetFloat("_ColumnAmount", graphData.Values.Length);
    }
}
