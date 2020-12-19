using System.Collections.Generic;
using UnityEngine;

public class ForceDirectedGraphVisualizer : BaseGraphVisualizer<UndirectedGraphData>
{
    [SerializeField] private GameObject nodePrefab;

    protected override void Redraw(UndirectedGraphData graphData)
    {
        var nodes = SpawnNodes(graphData.NumberOfNodes);
        foreach (var (i, j) in graphData.Edges)
        {
            SpawnEdge(nodes[i], nodes[j]);
        }
    }

    private IReadOnlyList<GameObject> SpawnNodes(int quantity)
    {
        var nodes = new List<GameObject>(quantity);
        for (var i = 0; i < quantity; i++)
        {
            var initialPosition = transform.position + Random.insideUnitSphere / 2;
            nodes.Add(Instantiate(nodePrefab, initialPosition, Quaternion.identity, transform));
        }
        return nodes;
    }

    private static void SpawnEdge(GameObject firstNode, GameObject secondNode)
    {
        var joint = firstNode.AddComponent<SpringJoint>();
        joint.enableCollision = true;
        joint.connectedBody = secondNode.GetComponent<Rigidbody>();
    }
}
