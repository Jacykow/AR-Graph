using System;
using UnityEngine;

public class SimpleAxisVisualizer : MonoBehaviour, IShowable
{
    [Serializable]
    private class Axis : IAxisProperties
    {
        [SerializeField] private AxisRenderer renderer;
        [SerializeField] private float length = 1f;

        public Vector3 Direction { get; }
        public float Length => length;

        public Axis(Vector3 direction)
        {
            Direction = direction;
        }

        public void Show()
        {
            renderer.Redraw(this);
        }
    }

    [Header("Axes")]

    [SerializeField] private Axis xAxis = new Axis(Vector3.right);

    [SerializeField] private Axis yAxis = new Axis(Vector3.up);

    [SerializeField] private Axis zAxis = new Axis(Vector3.forward);

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
