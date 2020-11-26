using System;
using UnityEngine;

public abstract class BaseGraphVisualizer<T> : MonoBehaviour, IGraphVisualizer where T : class, IGraphVisualizationData
{
    public Type GetGraphDataType()
    {
        return typeof(T);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show(IGraphVisualizationData graphVisualizationData)
    {
        gameObject.SetActive(true);
        Redraw(graphVisualizationData as T);
    }

    protected abstract void Redraw(T graphData);
}
