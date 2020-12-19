using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PieChart2DVisualizer : BaseGraphVisualizer<PieChart2DData>
{
    [SerializeField] private Transform background;
    [SerializeField] private GameObject piePrefab;

    protected override void Redraw(PieChart2DData graphData)
    {
        var angles = GetAngles(graphData.Values);
        var last = 0;

        for (var i = 0; i < angles.Length; i++)
        {
            var arc = 360 - (angles[i] - last);
            var rotation = last;
            last = angles[i];
            var fragment = Instantiate(piePrefab, background, true);
            var material = fragment.GetComponent<Renderer>().material;
            material.SetInt("_Arc1", arc);
            material.SetInt("_Angle", rotation);
            material.color = new Color(Random.value, Random.value, Random.value);
        }
    }

    private static int[] GetAngles(IReadOnlyList<float> values)
    {
        var sum = values.Sum();
        var aggregateAngles = new int[values.Count];
        var partialSum = 0f;

        for (var i = 0; i < values.Count; i++)
        {
            partialSum += values[i];
            aggregateAngles[i] = (int)(360 * partialSum / sum);
        }

        return aggregateAngles;
    }
}
