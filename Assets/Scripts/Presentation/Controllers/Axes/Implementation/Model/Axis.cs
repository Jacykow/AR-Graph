using System;
using UnityEngine;

[Serializable]
internal class Axis : IAxisProperties
{
    [SerializeField] private float length = 1f;
    [SerializeField] private string name;

    public AxisRenderer Renderer { get; set; }
    public Vector3 Direction { get; }
    public float Length => length;
    public string Name => name;

    public Axis(Vector3 direction)
    {
        Direction = direction;
    }

    public void Show()
    {
        Renderer?.Redraw(this);
    }
}
