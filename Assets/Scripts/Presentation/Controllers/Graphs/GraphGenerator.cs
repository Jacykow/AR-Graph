using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GraphGenerator : MonoBehaviour
{
    [SerializeField] private Transform visualizerContainer;

    private Dictionary<Type, IGraphVisualizer> visualizers;

    private IAxisVisualizer axes;

    private void Awake()
    {
        visualizers = visualizerContainer.
            GetComponentsInChildren<IGraphVisualizer>().
            ToDictionary(visualizer => visualizer.GetGraphDataType());
        foreach (var visualizer in visualizers.Values)
        {
            visualizer.Hide();
        }

        axes = GetComponentInChildren<IAxisVisualizer>();
        axes.Hide();
    }

    public void ShowGraph(IGraphVisualizationData data)
    {
        var dataType = data.GetType();
        if (visualizers.ContainsKey(dataType))
        {
            visualizers[dataType].Show(data);
            axes.Show();
        }
        else
        {
            Debug.LogWarning("Unsupported graph type!");
        }
    }
}
