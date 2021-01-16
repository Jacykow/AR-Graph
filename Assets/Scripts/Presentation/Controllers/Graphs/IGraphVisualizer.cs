using Assets.Scripts.BLL.Models.GraphData;
using System;

public interface IGraphVisualizer
{
    void Hide();
    void Show(IGraphVisualizationData graphVisualizationData);
    Type GetGraphDataType();
    GraphDisplayProperties DisplayProperties { get; }
}
