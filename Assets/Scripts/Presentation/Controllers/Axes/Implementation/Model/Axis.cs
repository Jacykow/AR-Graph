using System;
using UnityEngine;

[Serializable]
internal class Axis : IAxisProperties
{
    [SerializeField] private float length = 1f;

    public AxisRenderer Renderer { get; set; }
    public Vector3 Direction { get; }
    public float Length => length;

    public Axis(Vector3 direction)
    {
        Direction = direction;
    }

    public void Show()
    {
        Renderer?.Redraw(this);
    }
}
