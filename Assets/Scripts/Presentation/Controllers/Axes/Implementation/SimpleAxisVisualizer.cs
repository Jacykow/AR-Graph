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

    [Header("Axes")]

    [SerializeField] private GameObject prefab;

    [SerializeField] private Axis xAxis = new Axis(Vector3.right);

    [SerializeField] private Axis yAxis = new Axis(Vector3.up);

    [SerializeField] private Axis zAxis = new Axis(Vector3.forward);

    private void Awake()
    {
        if (prefab != null && prefab.GetComponent<AxisRenderer>() != null)
        {
            AxisRenderer AxisRenderer() =>
                Instantiate(prefab, transform.position, Quaternion.identity, transform)
                    .GetComponent<AxisRenderer>();

            xAxis.Renderer = AxisRenderer();
            yAxis.Renderer = AxisRenderer();
            zAxis.Renderer = AxisRenderer();
        }
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
    }
}
