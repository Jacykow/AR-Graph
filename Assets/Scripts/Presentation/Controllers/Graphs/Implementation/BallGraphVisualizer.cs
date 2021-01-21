using Assets.Scripts.BLL.Models.GraphData.Implementation;
using System.Collections.Generic;
using UnityEngine;

public class BallGraphVisualizer : BaseGraphVisualizer<BallGraphData>
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Color defaultColor = Color.white;

    private readonly List<GameObject> balls = new List<GameObject>();

    protected override void Redraw(BallGraphData graphData)
    {
        foreach (var ball in balls)
        {
            Destroy(ball);
        }
        balls.Clear();

        var metaData = graphData.MetaData as BallGraphMetaData;
        var colors = metaData?.Colors ?? new[] { defaultColor };
        for (var i = 0; i < graphData.BallPositions.Length; i++)
        {
            var point = graphData.BallPositions[i];
            var ball = Instantiate(ballPrefab, transform.position, Quaternion.identity, transform);
            var color = colors[i % colors.Length];
            ball.transform.localPosition = Vector3.Scale(point, graphData.MetaData.Scale);
            ball.GetComponent<Renderer>().material.color = color;
            balls.Add(ball);
        }
    }
}
