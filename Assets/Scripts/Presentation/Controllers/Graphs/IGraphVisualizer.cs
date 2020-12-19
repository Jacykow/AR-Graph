using System;

public interface IGraphVisualizer
{
    void Hide();
    void Show(IGraphVisualizationData graphVisualizationData);
    Type GetGraphDataType();
}
