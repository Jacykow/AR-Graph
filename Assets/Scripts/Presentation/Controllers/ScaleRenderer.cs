using System.Linq;
using UnityEngine;

public class ScaleRenderer : MonoBehaviour
{
    [SerializeField] private GameObject labelPrefab;
    [SerializeField] private int skipLabels;
    [SerializeField] private float scaleOffset = 0.1f;

    private const int MaxNumberOfLabels = 10;
    private Transform[] labels;

    public Transform LabelParent { get; set; }
    public Transform LookAtTarget { get; set; }

    private void InstantiateLabels()
    {
        labels = new Transform[MaxNumberOfLabels];
        for (var i = 0; i < labels.Length; i++)
        {
            var label = Instantiate(labelPrefab, Vector3.zero, Quaternion.identity, LabelParent).transform;
            label.gameObject.SetActive(false);
            labels[i] = label;
        }
    }

    private void Update()
    {
        if (labels == null) return;
        foreach (var label in labels)
        {
            label.LookAt(LookAtTarget, Vector3.up);
        }
    }

    public void Redraw(IAxisProperties axis, GridRenderer grid)
    {
        transform.position = grid.transform.position * 2 - axis.Direction * axis.Length;
        transform.position += transform.position.normalized * scaleOffset;

        if (labels == null) InstantiateLabels();
        var positions = grid.GetScaleMarks().ToArray();
        for (var i = skipLabels; i < positions.Length; i++)
        {
            labels[i].position = transform.position + axis.Direction * positions[i];
            labels[i].gameObject.SetActive(true);
        }

        for (var i = positions.Length; i < labels.Length; i++)
        {
            labels[i].gameObject.SetActive(false);
        }
    }
}
