using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SimpleAxisRenderer : AxisRenderer
{
    [SerializeField] private float coneOffset = 0.1f;

    private LineRenderer lineRenderer;
    private Transform cone;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        cone = GetComponentInChildren<MeshRenderer>().transform;
    }

    public override void Redraw(IAxisProperties properties)
    {
        var end = properties.Direction * (properties.Length + coneOffset);
        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(new[] { transform.position, transform.position + transform.rotation * Vector3.Scale(end, transform.lossyScale) });
        cone.localPosition = end;
        cone.localRotation = Quaternion.LookRotation(properties.Direction);
    }
}
