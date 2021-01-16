using TMPro;
using UnityEngine;

public class SimpleAxisVisualizer : MonoBehaviour, IAxisVisualizer
{

    [SerializeField] private GameObject axisPrefab;
    [SerializeField] private GameObject gridPrefab;
    [SerializeField] private GameObject scalePrefab;
    [SerializeField] private TMP_Text graphTitle;
    [SerializeField] private Canvas labelCanvas;

    private Axis xAxis = new Axis(Vector3.right);
    private Axis yAxis = new Axis(Vector3.up);
    private Axis zAxis = new Axis(Vector3.forward);
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

            xToYGrid.ScaleRenderer = ScaleRenderer();
            xToZGrid.ScaleRenderer = ScaleRenderer();
            yToXGrid.ScaleRenderer = ScaleRenderer();
            yToZGrid.ScaleRenderer = ScaleRenderer();
            zToXGrid.ScaleRenderer = ScaleRenderer();
            zToYGrid.ScaleRenderer = ScaleRenderer();
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

    public void Show(GraphDisplayProperties displayProperties, IGraphMetaData metaData)
    {
        CurrentDisplayProperties = displayProperties;
        gameObject.SetActive(true);
        graphTitle.text = metaData.Title;
        xAxis.Name = metaData.AxisNames[0];
        xAxis.Length = metaData.AxisLengths.x;
        xAxis.Show(displayProperties.xAxis);
        yAxis.Name = metaData.AxisNames[1];
        yAxis.Length = metaData.AxisLengths.y;
        yAxis.Show(displayProperties.yAxis);
        zAxis.Name = metaData.AxisNames[2];
        zAxis.Length = metaData.AxisLengths.z;
        zAxis.Show(displayProperties.zAxis);
        xToYGrid.Scale = metaData.Scale.x;
        xToYGrid.Show(displayProperties.xToYGrid);
        xToZGrid.Scale = metaData.Scale.x;
        xToZGrid.Show(displayProperties.xToZGrid);
        yToXGrid.Scale = metaData.Scale.y;
        yToXGrid.Show(displayProperties.yToXGrid);
        yToZGrid.Scale = metaData.Scale.y;
        yToZGrid.Show(displayProperties.yToZGrid);
        zToXGrid.Scale = metaData.Scale.z;
        zToXGrid.Show(displayProperties.zToXGrid);
        zToYGrid.Scale = metaData.Scale.z;
        zToYGrid.Show(displayProperties.zToYGrid);
        labelCanvas.enabled = true;
    }
}
