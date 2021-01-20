﻿using UnityEngine;

public class BallGraphMetaData : IGraphMetaData
{
    public string Title { get; set; }
    public string[] AxisNames { get; set; }
    public Vector3 Scale { get; set; }
    public Vector3 AxisLengths { get; set; }
    public string[] Labels { get; set; }
    public Color[] Colors { get; set; }
}
