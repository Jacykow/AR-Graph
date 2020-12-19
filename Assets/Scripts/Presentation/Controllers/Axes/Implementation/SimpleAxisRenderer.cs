using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SimpleAxisRenderer : AxisRenderer
{
    private LineRenderer lineRenderer;
    private Transform cone;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        cone = GetComponentInChildren<MeshRenderer>().transform;
    }

    public override void Redraw(IAxisProperties properties)
    {
        Vector3 end = properties.Direction * properties.Length;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(new[] { Vector3.zero, end });
        cone.position = end;
        cone.rotation = Quaternion.LookRotation(properties.Direction);
    }
}
