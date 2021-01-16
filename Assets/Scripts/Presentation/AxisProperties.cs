using System;
using UnityEngine;

[Serializable]
public class AxisProperties
{
    [SerializeField] private bool enabled;

    public bool Enabled => enabled;
}
