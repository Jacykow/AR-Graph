using TMPro;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SimpleAxisRenderer : AxisRenderer
{
    [SerializeField] private float axisWidth = 0.015f;
    [SerializeField] private float coneOffset = 0.1f;
    [SerializeField] private GameObject labelPrefab;
    [SerializeField] private float labelOffset = 0.2f;

    private LineRenderer lineRenderer;
    private Transform cone;
    private TMP_Text label;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        cone = GetComponentInChildren<MeshRenderer>().transform;
    }

    public override void Redraw(IAxisProperties properties)
    {
        var end = properties.Direction * (properties.Length + coneOffset);
        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(new[] { transform.position, transform.TransformPoint(end) });
        lineRenderer.startWidth = lineRenderer.endWidth = axisWidth * transform.lossyScale.x;
        cone.localPosition = end;
        cone.localRotation = Quaternion.LookRotation(properties.Direction);
        DrawLabel(properties);
        lineRenderer.enabled = true;
        cone.gameObject.SetActive(true);
        label.gameObject.SetActive(true);
    }

    public override void Hide()
    {
        lineRenderer.enabled = false;
        cone.gameObject.SetActive(false);
        label?.gameObject.SetActive(false);
    }

    private void DrawLabel(IAxisProperties properties)
    {
        if (label == null)
        {
            var parent = GameObject.FindWithTag("Graph Labels");
            if (labelPrefab == null || parent == null) return;
            label = Instantiate(labelPrefab, transform.position, transform.rotation, parent.transform).GetComponent<TMP_Text>();
        }
        var labelPosition = properties.Direction * (properties.Length + labelOffset);
        label.transform.position = transform.TransformPoint(labelPosition);
        label.text = properties.Name;
        label.GetComponent<TransformScaler>().Rescale(transform);
    }
}
