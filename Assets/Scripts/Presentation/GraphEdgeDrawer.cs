using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class GraphEdgeDrawer : MonoBehaviour
{
    [SerializeField] private float baseWidth = 0.125f;

    private Transform node;
    private Transform[] neighbors;
    private LineRenderer lineRenderer;
    private Vector3[] positions;

    private void Awake()
    {
        node = transform;
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    private void Start()
    {
        neighbors = GetComponents<SpringJoint>().Select(joint => joint.connectedBody.transform).ToArray();
        lineRenderer.positionCount = 2 * neighbors.Length;
        lineRenderer.startWidth = lineRenderer.endWidth = baseWidth * transform.lossyScale.x;
        positions = new Vector3[lineRenderer.positionCount];
    }

    private void Update()
    {
        for (var i = 0; i < neighbors.Length; i++)
        {
            positions[2 * i] = node.position;
            positions[2 * i + 1] = neighbors[i].position;
        }
        lineRenderer.SetPositions(positions);
    }
}
