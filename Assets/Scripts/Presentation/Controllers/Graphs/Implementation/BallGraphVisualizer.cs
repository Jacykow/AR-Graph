using UnityEngine;

public class BallGraphVisualizer : BaseGraphVisualizer<BallGraphData>
{
    [SerializeField] private GameObject ballPrefab;

    protected override void Redraw(BallGraphData graphData)
    {
        foreach (var point in graphData.BallPositions)
        {
            Instantiate(ballPrefab, point, Quaternion.identity, transform);
        }
    }
}
