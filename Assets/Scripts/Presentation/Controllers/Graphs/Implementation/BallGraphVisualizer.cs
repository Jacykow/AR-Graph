using System.Collections.Generic;
using UnityEngine;

public class BallGraphVisualizer : BaseGraphVisualizer<BallGraphData>
{
    [SerializeField] private GameObject ballPrefab;

    private readonly List<GameObject> balls = new List<GameObject>();

    protected override void Redraw(BallGraphData graphData)
    {
        foreach (var ball in balls)
        {
            Destroy(ball);
        }
        balls.Clear();

        foreach (var point in graphData.BallPositions)
        {
            var ball = Instantiate(ballPrefab, transform.position, Quaternion.identity, transform);
            ball.transform.localPosition = Vector3.Scale(point, graphData.MetaData.Scale);
            balls.Add(ball);
        }
    }
}
