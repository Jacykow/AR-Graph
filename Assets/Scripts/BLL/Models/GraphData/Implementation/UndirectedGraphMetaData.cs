using UnityEngine;

public class UndirectedGraphMetaData : IGraphMetaData
{
    public string Title { get; set; }
    public string[] AxisNames { get; set; }
    public Vector3 Scale { get; set; }
    public Vector3 AxisLengths { get; set; }
}
