using System;
using UnityEngine;

[Serializable]
internal class Grid
{
    [SerializeField] private bool enabled;

    public GridRenderer Renderer { get; set; }
    public IAxisProperties PrimaryAxis { get; set; }
    public IAxisProperties SecondaryAxis { get; set; }

    public void Show()
    {
        if (!enabled || Renderer == null) return;
        Renderer.gameObject.SetActive(true);
        Renderer.Redraw(PrimaryAxis, SecondaryAxis);
    }
}
