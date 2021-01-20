using System;
using System.Collections.Generic;

[Serializable]
internal class Grid
{
    public GridRenderer Renderer { get; set; }
    public ScaleRenderer ScaleRenderer { get; set; }
    public LabelRenderer LabelRenderer { get; set; }
    public IAxisProperties PrimaryAxis { get; set; }
    public IAxisProperties SecondaryAxis { get; set; }
    public float Scale { get; set; } = 1f;
    public IReadOnlyList<string> Labels { get; set; }

    public void Show(GridProperties properties)
    {
        var drawLabels = properties.ShowLabels && LabelRenderer != null && Labels != null && Labels.Count > 0;

        if (!properties.Enabled && !drawLabels || Renderer == null) return;
        Renderer.Scale = Scale;
        Renderer.Redraw(PrimaryAxis, SecondaryAxis);
        Renderer.gameObject.SetActive(true);

        if (drawLabels)
        {
            LabelRenderer.Redraw(PrimaryAxis, Renderer, Labels);
            if (!properties.Enabled)
            {
                Renderer.Hide();
                return;
            }
        }

        if (properties.ShowScale && ScaleRenderer != null)
        {
            ScaleRenderer.Redraw(PrimaryAxis, Renderer);
        }
    }

    public void Hide()
    {
        Renderer?.Hide();
        ScaleRenderer?.Hide();
        LabelRenderer?.Hide();
    }
}
