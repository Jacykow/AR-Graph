using UnityEngine;

public class SimpleAxisVisualizer : MonoBehaviour, IAxisVisualizer
{

    [SerializeField] private GameObject axisPrefab;
    [SerializeField] private Axis xAxis = new Axis(Vector3.right);
    [SerializeField] private Axis yAxis = new Axis(Vector3.up);
    [SerializeField] private Axis zAxis = new Axis(Vector3.forward);
    [SerializeField] private GameObject gridPrefab;
    [SerializeField] private GameObject scalePrefab;
    [SerializeField] private Canvas labelCanvas;

    private Grid xToYGrid = new Grid();
    private Grid xToZGrid = new Grid();
    private Grid yToXGrid = new Grid();
    private Grid yToZGrid = new Grid();
    private Grid zToXGrid = new Grid();
    private Grid zToYGrid = new Grid();

    public IAxisProperties XAxis => xAxis;
    public IAxisProperties YAxis => yAxis;
    public IAxisProperties ZAxis => zAxis;
    public GraphDisplayProperties CurrentDisplayProperties { get; private set; }

    private void Awake()
    {
        if (axisPrefab != null && axisPrefab.GetComponent<AxisRenderer>() != null)
        {
            AxisRenderer AxisRenderer() =>
                Instantiate(axisPrefab, transform.position, transform.rotation, transform)
                    .GetComponent<AxisRenderer>();

            xAxis.Renderer = AxisRenderer();
            yAxis.Renderer = AxisRenderer();
            zAxis.Renderer = AxisRenderer();
        }

        if (gridPrefab != null && gridPrefab.GetComponent<GridRenderer>() != null)
        {
            GridRenderer GridRenderer() =>
                Instantiate(gridPrefab, transform.position, transform.rotation, transform)
                    .GetComponent<GridRenderer>();

            xToYGrid.Renderer = GridRenderer();
            xToZGrid.Renderer = GridRenderer();
            yToXGrid.Renderer = GridRenderer();
            yToZGrid.Renderer = GridRenderer();
            zToXGrid.Renderer = GridRenderer();
            zToYGrid.Renderer = GridRenderer();
        }

        if (scalePrefab != null && scalePrefab.GetComponent<ScaleRenderer>() != null)
        {
            ScaleRenderer ScaleRenderer()
            {
                var scale = Instantiate(scalePrefab, transform.position, transform.rotation, transform)
                    .GetComponent<ScaleRenderer>();
                return scale;
            }

            xToYGrid.Scale = ScaleRenderer();
            xToZGrid.Scale = ScaleRenderer();
            yToXGrid.Scale = ScaleRenderer();
            yToZGrid.Scale = ScaleRenderer();
            zToXGrid.Scale = ScaleRenderer();
            zToYGrid.Scale = ScaleRenderer();
        }

        xToYGrid.PrimaryAxis = xAxis;
        xToYGrid.SecondaryAxis = yAxis;
        xToZGrid.PrimaryAxis = xAxis;
        xToZGrid.SecondaryAxis = zAxis;
        yToXGrid.PrimaryAxis = yAxis;
        yToXGrid.SecondaryAxis = xAxis;
        yToZGrid.PrimaryAxis = yAxis;
        yToZGrid.SecondaryAxis = zAxis;
        zToXGrid.PrimaryAxis = zAxis;
        zToXGrid.SecondaryAxis = xAxis;
        zToYGrid.PrimaryAxis = zAxis;
        zToYGrid.SecondaryAxis = yAxis;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        xAxis.Hide();
        yAxis.Hide();
        zAxis.Hide();
        xToYGrid.Hide();
        xToZGrid.Hide();
        yToXGrid.Hide();
        yToZGrid.Hide();
        zToXGrid.Hide();
        zToYGrid.Hide();
        labelCanvas.enabled = false;
    }

    public void Show(GraphDisplayProperties displayProperties)
    {
        CurrentDisplayProperties = displayProperties;
        gameObject.SetActive(true);
        xAxis.Show(displayProperties.xAxis);
        yAxis.Show(displayProperties.yAxis);
        zAxis.Show(displayProperties.zAxis);
        xToYGrid.Show(displayProperties.xToYGrid);
        xToZGrid.Show(displayProperties.xToZGrid);
        yToXGrid.Show(displayProperties.yToXGrid);
        yToZGrid.Show(displayProperties.yToZGrid);
        zToXGrid.Show(displayProperties.zToXGrid);
        zToYGrid.Show(displayProperties.zToYGrid);
        labelCanvas.enabled = true;
    }
}
