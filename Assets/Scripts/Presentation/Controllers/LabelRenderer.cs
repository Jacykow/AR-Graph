using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LabelRenderer : MonoBehaviour
{
    [SerializeField] private GameObject labelPrefab;
    [SerializeField] private float labelOffset = 0.1f;

    private const int MaxNumberOfLabels = 100;
    private TMP_Text[] labels;

    private void InstantiateLabels()
    {
        labels = new TMP_Text[MaxNumberOfLabels];
        var parent = GameObject.FindWithTag("Graph Labels");
        for (var i = 0; i < labels.Length; i++)
        {
            var label = Instantiate(labelPrefab, Vector3.zero, Quaternion.identity, parent.transform).GetComponent<TMP_Text>();
            label.GetComponent<TransformScaler>().Rescale(transform);
            label.gameObject.SetActive(false);
            labels[i] = label;
        }
    }

    public void Redraw(IAxisProperties axis, GridRenderer grid, IReadOnlyList<string> labelList)
    {
        transform.localPosition = grid.transform.localPosition * 2 - axis.Direction * axis.Length;
        transform.localPosition += transform.localPosition.normalized * labelOffset;

        if (labels == null) InstantiateLabels();
        var interval = axis.Length / labelList.Count;
        for (var i = 0; i < labelList.Count && i < labels.Length; i++)
        {
            labels[i].transform.position = transform.TransformPoint(axis.Direction * interval * (i + 0.5f));
            labels[i].text = labelList[i];
            labels[i].GetComponent<TransformScaler>().Rescale(transform);
            labels[i].gameObject.SetActive(true);
        }

        for (var i = labelList.Count; i < labels.Length; i++)
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
