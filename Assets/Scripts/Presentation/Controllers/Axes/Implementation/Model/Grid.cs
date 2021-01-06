using System;
using UnityEngine;

[Serializable]
internal class Grid
{
    [SerializeField] private bool enabled;
    [SerializeField] private bool showScale;

    public GridRenderer Renderer { get; set; }
    public ScaleRenderer Scale { get; set; }
    public IAxisProperties PrimaryAxis { get; set; }
    public IAxisProperties SecondaryAxis { get; set; }

    public void Show()
    {
        if (!enabled || Renderer == null) return;
        Renderer.gameObject.SetActive(true);
        Renderer.Redraw(PrimaryAxis, SecondaryAxis);

        if (showScale && Scale != null)
        {
            Scale.Redraw(PrimaryAxis, Renderer);
        }
    }
}
