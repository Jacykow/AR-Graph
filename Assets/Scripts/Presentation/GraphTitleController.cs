using UnityEngine;

public class GraphTitleController : MonoBehaviour
{
    [SerializeField] private Transform graph;
    [SerializeField] private Vector3 offset;

    private TransformScaler scaler;

    private void Awake()
    {
        scaler = GetComponent<TransformScaler>();
    }

    private void Update()
    {
        transform.position = graph.TransformPoint(offset);
        scaler.Rescale(graph);
    }
}
