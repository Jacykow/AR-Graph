using UnityEngine;

public class SimpleAxisVisualizer : MonoBehaviour, IShowable
{
    [Header("Axes")]

    [SerializeField] private GameObject axisPrefab;

    [SerializeField] private Axis xAxis = new Axis(Vector3.right);

    [SerializeField] private Axis yAxis = new Axis(Vector3.up);

    [SerializeField] private Axis zAxis = new Axis(Vector3.forward);

    [Header("Grid")]

    [SerializeField] private GameObject gridPrefab;

    [Tooltip("Lines for X axis on XY plane")]
    [SerializeField] private Grid xToYGrid;

    [Tooltip("Lines for X axis on XZ plane")]
    [SerializeField] private Grid xToZGrid;

    [Tooltip("Lines for Y axis on XY plane")]
    [SerializeField] private Grid yToXGrid;

    [Tooltip("Lines for Y axis on YZ plane")]
    [SerializeField] private Grid yToZGrid;

    [Tooltip("Lines for Z axis on XZ plane")]
    [SerializeField] private Grid zToXGrid;

    [Tooltip("Lines for Z axis on YZ plane")]
    [SerializeField] private Grid zToYGrid;

    [Header("Scale")]

    [SerializeField] private GameObject scalePrefab;

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
    }

    public void Show()
    {
        gameObject.SetActive(true);
        xAxis.Show();
        yAxis.Show();
        zAxis.Show();
        xToYGrid.Show();
        xToZGrid.Show();
        yToXGrid.Show();
        yToZGrid.Show();
        zToXGrid.Show();
        zToYGrid.Show();
    }
}
