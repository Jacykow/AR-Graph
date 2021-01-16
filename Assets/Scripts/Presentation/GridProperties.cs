using System;
using UnityEngine;

[Serializable]
public class GridProperties
{
    [SerializeField] private bool enabled;
    [SerializeField] private bool showScale;

    public bool Enabled => enabled;
    public bool ShowScale => showScale;
}
