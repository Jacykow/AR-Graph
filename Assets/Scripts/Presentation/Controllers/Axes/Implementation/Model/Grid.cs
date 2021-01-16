using System;

[Serializable]
internal class Grid
{
    public GridRenderer Renderer { get; set; }
    public ScaleRenderer ScaleRenderer { get; set; }
    public IAxisProperties PrimaryAxis { get; set; }
    public IAxisProperties SecondaryAxis { get; set; }
    public float Scale { get; set; } = 1f;

    public void Show(GridProperties properties)
    {
        if (!properties.Enabled || Renderer == null) return;
        Renderer.Scale = Scale;
        Renderer.Redraw(PrimaryAxis, SecondaryAxis);
        Renderer.gameObject.SetActive(true);

        if (properties.ShowScale && ScaleRenderer != null)
        {
            ScaleRenderer.Redraw(PrimaryAxis, Renderer);
        }
    }

    public void Hide()
    {
        Renderer?.Hide();
        ScaleRenderer?.Hide();
    }
}
