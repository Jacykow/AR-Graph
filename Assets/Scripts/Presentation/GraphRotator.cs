using UnityEngine;

public class GraphRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;

    private SimpleAxisVisualizer axes;

    private void Awake()
    {
        axes = GetComponentInChildren<SimpleAxisVisualizer>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var delta = -Input.GetAxis("Mouse X");
            transform.Rotate(transform.up, rotationSpeed * delta);
            transform.localPosition = transform.localRotation * -GetAxesCenter();
            axes.Show(axes.CurrentDisplayProperties);
        }
    }

    private Vector3 GetAxesCenter()
    {
        return axes.XAxis.Direction * axes.XAxis.Length / 2f +
               axes.ZAxis.Direction * axes.ZAxis.Length / 2f;
    }
}
