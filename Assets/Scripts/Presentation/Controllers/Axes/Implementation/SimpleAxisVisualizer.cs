using System.Linq;
using TMPro;
using UnityEngine;

public class SimpleAxisVisualizer : MonoBehaviour, IAxisVisualizer
{

    [SerializeField] private GameObject axisPrefab;
    [SerializeField] private GameObject gridPrefab;
    [SerializeField] private GameObject scalePrefab;
    [SerializeField] private GameObject labelsPrefab;
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
    private GraphDisplayProperties currentDisplayProperties;

    public Vector3 Dimensions => new Vector3(xAxis.Length, yAxis.Length, zAxis.Length);

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

        if (scalePrefab != null && scalePrefab.GetComponent<ScaleRenderer>() != null)
        {
            LabelRenderer LabelRenderer()
            {
                var labels = Instantiate(labelsPrefab, transform.position, transform.rotation, transform)
                    .GetComponent<LabelRenderer>();
                return labels;
            }

            xToYGrid.LabelRenderer = LabelRenderer();
            xToZGrid.LabelRenderer = LabelRenderer();
            yToXGrid.LabelRenderer = LabelRenderer();
            yToZGrid.LabelRenderer = LabelRenderer();
            zToXGrid.LabelRenderer = LabelRenderer();
            zToYGrid.LabelRenderer = LabelRenderer();
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
        currentDisplayProperties = displayProperties;
        gameObject.SetActive(true);
        graphTitle.text = metaData.Title;
        xAxis.Name = metaData.AxisNames?.ElementAtOrDefault(0);
        xAxis.Length = metaData.AxisLengths.x;
        yAxis.Name = metaData.AxisNames?.ElementAtOrDefault(1);
        yAxis.Length = metaData.AxisLengths.y;
        zAxis.Name = metaData.AxisNames?.ElementAtOrDefault(2);
        zAxis.Length = metaData.AxisLengths.z;
        xToYGrid.Scale = metaData.Scale.x;
        xToYGrid.Labels = metaData.LabelsX;
        xToZGrid.Scale = metaData.Scale.x;
        xToZGrid.Labels = metaData.LabelsX;
        yToXGrid.Scale = metaData.Scale.y;
        yToZGrid.Scale = metaData.Scale.y;
        zToXGrid.Scale = metaData.Scale.z;
        zToXGrid.Labels = metaData.LabelsZ;
        zToYGrid.Scale = metaData.Scale.z;
        zToYGrid.Labels = metaData.LabelsZ;
        Redraw();
        labelCanvas.enabled = true;
    }

    public void Redraw()
    {
        if (currentDisplayProperties == null) return;
        xAxis.Show(currentDisplayProperties.xAxis);
        yAxis.Show(currentDisplayProperties.yAxis);
        zAxis.Show(currentDisplayProperties.zAxis);
        xToYGrid.Show(currentDisplayProperties.xToYGrid);
        xToZGrid.Show(currentDisplayProperties.xToZGrid);
        yToXGrid.Show(currentDisplayProperties.yToXGrid);
        yToZGrid.Show(currentDisplayProperties.yToZGrid);
        zToXGrid.Show(currentDisplayProperties.zToXGrid);
        zToYGrid.Show(currentDisplayProperties.zToYGrid);
    }
}
