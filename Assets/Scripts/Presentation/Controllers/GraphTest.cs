using UnityEngine;

public class GraphTest : MonoBehaviour
{
    [SerializeField] private GraphGenerator graphGenerator;

    private void Start()
    {
        graphGenerator.ShowGraph(TestGraphVisualizationData.UndirectedGraph);
    }
}
