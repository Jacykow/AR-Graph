using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class GraphGenerator : MonoBehaviour
{
    [SerializeField] private Transform visualizerContainer;

    private Dictionary<Type, IGraphVisualizer> visualizers;
    private IGraphVisualizer activeVisualizer;
    private IShowable axes;

    private void Awake()
    {
        visualizers = visualizerContainer.
            GetComponentsInChildren<IGraphVisualizer>().
            ToDictionary(visualizer => visualizer.GetGraphDataType());
        foreach (var visualizer in visualizers.Values)
        {
            visualizer.Hide();
        }

        axes = GetComponentInChildren<IShowable>();
        axes.Hide();
    }

    private void Start()
    {
        DataManager.Main.GraphDataProperty.Subscribe(graphData =>
        {
            ShowGraph(graphData);
        }).AddTo(this);
    }

    public void ShowGraph(IGraphVisualizationData data)
    {
        if (activeVisualizer != null)
        {
            activeVisualizer.Hide();
            axes.Hide();
        }

        var dataType = data.GetType();
        if (visualizers.ContainsKey(dataType))
        {
            activeVisualizer = visualizers[dataType];
            activeVisualizer.Show(data);
            axes.Show();
        }
        else
        {
            Debug.LogWarning("Unsupported graph type!");
        }
    }
}
