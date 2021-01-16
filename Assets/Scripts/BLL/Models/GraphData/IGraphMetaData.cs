using UnityEngine;

public interface IGraphMetaData
{
    string Title { get; set; }
    string[] AxisNames { get; set; }
    Vector3 Scale { get; set; }
    Vector3 AxisLengths { get; set; }
}
