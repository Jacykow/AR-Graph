using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GraphDisplayProperties", menuName = "Graph/GraphDisplayProperties")]
public class GraphDisplayProperties : ScriptableObject
{
    [Header("Axes")]

    public AxisProperties xAxis;
    public AxisProperties yAxis;
    public AxisProperties zAxis;

    [Header("Grid")]

    [Tooltip("Lines for X axis on XY plane")]
    public GridProperties xToYGrid;
    [Tooltip("Lines for X axis on XZ plane")]
    public GridProperties xToZGrid;
    [Tooltip("Lines for Y axis on XY plane")]
    public GridProperties yToXGrid;
    [Tooltip("Lines for Y axis on YZ plane")]
    public GridProperties yToZGrid;
    [Tooltip("Lines for Z axis on XZ plane")]
    public GridProperties zToXGrid;
    [Tooltip("Lines for Z axis on YZ plane")]
    public GridProperties zToYGrid;
}

[Serializable]
public class AxisProperties
{
    [SerializeField] private bool enabled;

    public bool Enabled => enabled;
}

[Serializable]
public class GridProperties
{
    [SerializeField] private bool enabled;
    [SerializeField] private bool showScale;

    public bool Enabled => enabled;
    public bool ShowScale => showScale;
}
