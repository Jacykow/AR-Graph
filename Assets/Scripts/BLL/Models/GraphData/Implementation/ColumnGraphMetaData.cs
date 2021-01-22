using UnityEngine;

public class ColumnGraphMetaData : IGraphMetaData
{
    public string Title { get; set; }
    public string[] AxisNames { get; set; }
    public Vector3 Scale { get; set; }
    public Vector3 AxisLengths { get; set; }
    public string[] LabelsX { get; set; }
    public string[] LabelsZ { get; set; }
    public UnityReplacement.Color[] Colors { get; set; }
}
