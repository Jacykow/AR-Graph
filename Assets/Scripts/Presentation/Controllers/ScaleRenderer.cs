using System.Linq;
using UnityEngine;

public class ScaleRenderer : MonoBehaviour
{
    [SerializeField] private GameObject labelPrefab;
    [SerializeField] private int skipLabels;
    [SerializeField] private float scaleOffset = 0.1f;

    private const int MaxNumberOfLabels = 10;
    private Transform[] labels;

    private void InstantiateLabels()
    {
        labels = new Transform[MaxNumberOfLabels];
        var parent = GameObject.FindWithTag("Graph Labels");
        for (var i = 0; i < labels.Length; i++)
        {
            var label = Instantiate(labelPrefab, Vector3.zero, Quaternion.identity, parent.transform).transform;
            label.GetComponent<TransformScaler>().Rescale(transform);
            label.gameObject.SetActive(false);
            labels[i] = label;
        }
    }

    public void Redraw(IAxisProperties axis, GridRenderer grid)
    {
        transform.localPosition = grid.transform.localPosition * 2 - axis.Direction * axis.Length;
        transform.localPosition += transform.localPosition.normalized * scaleOffset;

        if (labels == null) InstantiateLabels();
        var positions = grid.GetScaleMarks().ToArray();
        for (var i = skipLabels; i < positions.Length; i++)
        {
            labels[i].position = transform.TransformPoint(axis.Direction * positions[i]);
            labels[i].gameObject.SetActive(true);
        }

        for (var i = positions.Length; i < labels.Length; i++)
        {
            labels[i].gameObject.SetActive(false);
        }
    }

    public void Hide()
    {
        if (labels == null) return;
        foreach (var label in labels)
        {
            label.gameObject.SetActive(false);
        }
    }
}
