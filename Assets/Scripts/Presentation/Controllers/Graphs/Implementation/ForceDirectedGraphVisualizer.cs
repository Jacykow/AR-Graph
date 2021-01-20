using Assets.Scripts.BLL.Models.GraphData.Implementation;
using System.Collections.Generic;
using UnityEngine;

public class ForceDirectedGraphVisualizer : BaseGraphVisualizer<UndirectedGraphData>
{
    [SerializeField] private GameObject nodePrefab;

    private readonly List<GameObject> nodes = new List<GameObject>();

    protected override void Redraw(UndirectedGraphData graphData)
    {
        foreach (var node in nodes)
        {
            Destroy(node);
        }

        SpawnNodes(graphData.NumberOfNodes);
        foreach (var (i, j) in graphData.Edges)
        {
            SpawnEdge(nodes[i], nodes[j]);
        }
    }

    private void SpawnNodes(int quantity)
    {
        nodes.Clear();
        for (var i = 0; i < quantity; i++)
        {
            var initialPosition = transform.position + Random.insideUnitSphere * transform.lossyScale.magnitude / 4;
            nodes.Add(Instantiate(nodePrefab, initialPosition, Quaternion.identity, transform));
        }
    }

    private static void SpawnEdge(GameObject firstNode, GameObject secondNode)
    {
        var joint = firstNode.AddComponent<SpringJoint>();
        joint.enableCollision = true;
        joint.connectedBody = secondNode.GetComponent<Rigidbody>();
    }
}
