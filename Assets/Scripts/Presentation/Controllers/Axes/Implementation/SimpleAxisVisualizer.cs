using System;
using UnityEngine;

public class SimpleAxisVisualizer : MonoBehaviour, IAxisVisualizer
{
    [Serializable]
    private class Axis : IAxisProperties
    {
        [SerializeField] private AxisRenderer renderer;
        [SerializeField] private float length;

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

    [SerializeField] private Axis x = new Axis(Vector3.right);

    [SerializeField] private Axis y = new Axis(Vector3.up);

    [SerializeField] private Axis z = new Axis(Vector3.forward);

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        x.Show();
        y.Show();
        z.Show();
    }
}
