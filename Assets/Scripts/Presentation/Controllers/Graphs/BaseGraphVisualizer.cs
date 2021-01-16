using Assets.Scripts.BLL.Models.GraphData;
using System;
using UnityEngine;

public abstract class BaseGraphVisualizer<T> : MonoBehaviour, IGraphVisualizer where T : class, IGraphVisualizationData
{
    [SerializeField] private GraphDisplayProperties displayProperties;

    public GraphDisplayProperties DisplayProperties => displayProperties;

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
