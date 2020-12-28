using System;
using UnityEngine;

public class SimpleAxisVisualizer : MonoBehaviour, IShowable
{
    [Serializable]
    private class Axis : IAxisProperties
    {
        [SerializeField] private float length = 1f;

        public AxisRenderer Renderer { get; set; }

        public Vector3 Direction { get; }
        public float Length => length;

        public Axis(Vector3 direction)
        {
            Direction = direction;
        }

        public void Show()
        {
            Renderer?.Redraw(this);
        }
    }

    [Serializable]
    private class Grid
    {
        [SerializeField] private bool enabled;

        public GridRenderer Renderer { get; set; }

        public IAxisProperties PrimaryAxis { get; set; }
        public IAxisProperties SecondaryAxis { get; set; }

        public void Show()
        {
            if (!enabled) return;
            Renderer.gameObject.SetActive(true);
            Renderer.Redraw(PrimaryAxis, SecondaryAxis);
        }
    }

    [Header("Axes")]

    [SerializeField] private GameObject axisPrefab;

    [SerializeField] private Axis xAxis = new Axis(Vector3.right);

    [SerializeField] private Axis yAxis = new Axis(Vector3.up);

    [SerializeField] private Axis zAxis = new Axis(Vector3.forward);

    [Header("Grid")]

    [SerializeField] private GameObject gridPrefab;

    [Tooltip("Lines for X axis on XY plane")]
    [SerializeField] private Grid xAxisToY;

    [Tooltip("Lines for X axis on XZ plane")]
    [SerializeField] private Grid xAxisToZ;

    [Tooltip("Lines for Y axis on XY plane")]
    [SerializeField] private Grid yAxisToX;

    [Tooltip("Lines for Y axis on YZ plane")]
    [SerializeField] private Grid yAxisToZ;

    [Tooltip("Lines for Z axis on XZ plane")]
    [SerializeField] private Grid zAxisToX;

    [Tooltip("Lines for Z axis on YZ plane")]
    [SerializeField] private Grid zAxisToY;

    private void Awake()
    {
        if (axisPrefab != null && axisPrefab.GetComponent<AxisRenderer>() != null)
        {
            AxisRenderer AxisRenderer() =>
                Instantiate(axisPrefab, transform.position, Quaternion.identity, transform)
                    .GetComponent<AxisRenderer>();

            xAxis.Renderer = AxisRenderer();
            yAxis.Renderer = AxisRenderer();
            zAxis.Renderer = AxisRenderer();
        }

        if (gridPrefab != null && gridPrefab.GetComponent<GridRenderer>() != null)
        {
            GridRenderer GridRenderer() =>
                Instantiate(gridPrefab, transform.position, Quaternion.identity, transform)
                    .GetComponent<GridRenderer>();

            xAxisToY.Renderer = GridRenderer();
            xAxisToZ.Renderer = GridRenderer();
            yAxisToX.Renderer = GridRenderer();
            yAxisToZ.Renderer = GridRenderer();
            zAxisToX.Renderer = GridRenderer();
            zAxisToY.Renderer = GridRenderer();
        }

        xAxisToY.PrimaryAxis = xAxis;
        xAxisToY.SecondaryAxis = yAxis;
        xAxisToZ.PrimaryAxis = xAxis;
        xAxisToZ.SecondaryAxis = zAxis;
        yAxisToX.PrimaryAxis = yAxis;
        yAxisToX.SecondaryAxis = xAxis;
        yAxisToZ.PrimaryAxis = yAxis;
        yAxisToZ.SecondaryAxis = zAxis;
        zAxisToX.PrimaryAxis = zAxis;
        zAxisToX.SecondaryAxis = xAxis;
        zAxisToY.PrimaryAxis = zAxis;
        zAxisToY.SecondaryAxis = yAxis;
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
        xAxisToY.Show();
        xAxisToZ.Show();
        yAxisToX.Show();
        yAxisToZ.Show();
        zAxisToX.Show();
        zAxisToY.Show();
    }
}
