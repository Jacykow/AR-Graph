using UnityEngine;

public class GraphGenerator : MonoBehaviour
{
    public GameObject ballPrefab;

    public void ShowGraph(GraphVisualizationData data)
    {
        if (data.graphType == GraphType.Balls)
        {
            foreach (var point in data.points)
            {
                Instantiate(ballPrefab, point, Quaternion.identity, transform);
            }
        }
    }
}
