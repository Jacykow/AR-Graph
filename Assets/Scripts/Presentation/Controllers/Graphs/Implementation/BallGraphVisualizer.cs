using UnityEngine;

public class BallGraphVisualizer : BaseGraphVisualizer<BallGraphData>
{
    [SerializeField] private GameObject ballPrefab;

    protected override void Redraw(BallGraphData graphData)
    {
        foreach (var point in graphData.BallPositions)
        {
            var ball = Instantiate(ballPrefab, transform.position, Quaternion.identity, transform);
            ball.transform.localPosition = point;
        }
    }
}
