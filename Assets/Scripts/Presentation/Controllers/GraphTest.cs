using UnityEngine;

public class GraphTest : MonoBehaviour
{
    public GraphGenerator graphGenerator;

    private void Start()
    {
        graphGenerator.ShowGraph(GraphVisualizationData.TestColumns());
    }
}
