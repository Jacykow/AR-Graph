﻿using Assets.Scripts.BLL.Models.GraphData.Implementation;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PieChart2DVisualizer : BaseGraphVisualizer<PieChart2DData>
{
    [SerializeField] private Transform background;
    [SerializeField] private GameObject piePrefab;

    private readonly List<GameObject> fragments = new List<GameObject>();

    protected override void Redraw(PieChart2DData graphData)
    {
        foreach (var fragment in fragments)
        {
            Destroy(fragment);
        }
        fragments.Clear();

        var metaData = graphData.MetaData as PieChart2DMetaData;
        var colors = metaData?.Colors;
        var angles = GetAngles(graphData.Values);
        var last = 0;
        for (var i = 0; i < angles.Length; i++)
        {
            var arc = 360 - (angles[i] - last);
            var rotation = last;
            last = angles[i];
            var fragment = Instantiate(piePrefab, background.position, background.rotation, background);
            var material = fragment.GetComponent<Renderer>().material;
            material.SetInt("_Arc1", arc);
            material.SetInt("_Angle", rotation);
            material.color = (colors != null && colors.Length > i) ? colors[i].ToUnityColor() : Color.HSVToRGB(Random.value, 1, 1);
            fragments.Add(fragment);
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
