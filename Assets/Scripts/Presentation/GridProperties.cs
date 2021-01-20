using System;
using UnityEngine;

[Serializable]
public class GridProperties
{
    [SerializeField] private bool enabled;
    [SerializeField] private bool showScale;
    [SerializeField] private bool showLabels;

    public bool Enabled => enabled;
    public bool ShowScale => showScale;
    public bool ShowLabels => showLabels;
}
