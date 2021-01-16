using System;
using UnityEngine;

[Serializable]
internal class Axis : IAxisProperties
{
    public AxisRenderer Renderer { get; set; }
    public Vector3 Direction { get; }
    public float Length { get; set; }
    public string Name { get; set; }

    public Axis(Vector3 direction)
    {
        Direction = direction;
    }

    public void Show(AxisProperties properties)
    {
        if (!properties.Enabled || Renderer == null) return;
        Renderer.Redraw(this);
    }

    public void Hide()
    {
        Renderer?.Hide();
    }
}
