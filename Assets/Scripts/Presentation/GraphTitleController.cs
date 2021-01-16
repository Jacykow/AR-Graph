using UnityEngine;

public class GraphTitleController : MonoBehaviour
{
    [SerializeField] private SimpleAxisVisualizer axes;
    [SerializeField] private float offset;

    private TransformScaler scaler;

    private void Awake()
    {
        scaler = GetComponent<TransformScaler>();
    }

    private void Update()
    {
        var position = new Vector3(axes.Dimensions.x / 2f, axes.Dimensions.y + offset, axes.Dimensions.z / 2f);
        transform.position = axes.transform.TransformPoint(position);
        scaler.Rescale(axes.transform);
    }
}
