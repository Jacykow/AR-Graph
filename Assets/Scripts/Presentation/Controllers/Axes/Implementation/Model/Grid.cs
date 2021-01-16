using System;

[Serializable]
internal class Grid
{
    public GridRenderer Renderer { get; set; }
    public ScaleRenderer Scale { get; set; }
    public IAxisProperties PrimaryAxis { get; set; }
    public IAxisProperties SecondaryAxis { get; set; }

    public void Show(GridProperties properties)
    {
        if (!properties.Enabled || Renderer == null) return;
        Renderer.gameObject.SetActive(true);
        Renderer.Redraw(PrimaryAxis, SecondaryAxis);
        Renderer.gameObject.SetActive(true);

        if (properties.ShowScale && Scale != null)
        {
            Scale.Redraw(PrimaryAxis, Renderer);
        }
    }

    public void Hide()
    {
        Renderer?.Hide();
        Scale?.Hide();
    }
}
