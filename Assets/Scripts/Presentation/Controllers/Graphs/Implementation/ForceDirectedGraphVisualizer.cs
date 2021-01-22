using Assets.Scripts.BLL.Models.GraphData.Implementation;
using System.Collections.Generic;
using UnityEngine;

public class ForceDirectedGraphVisualizer : BaseGraphVisualizer<UndirectedGraphData>
{
    [SerializeField] private GameObject nodePrefab;
    [SerializeField] private Color defaultNodeColor = Color.white;
    [SerializeField] private Color defaultEdgeColor = Color.blue;

    private readonly List<GameObject> nodes = new List<GameObject>();

    protected override void Redraw(UndirectedGraphData graphData)
    {
        foreach (var node in nodes)
        {
            Destroy(node);
        }

        var metaData = graphData.MetaData as UndirectedGraphMetaData;
        var nodeColors = metaData?.NodeColors ?? new[] { new UnityReplacement.Color(defaultNodeColor) };
        var edgeColor = metaData?.EdgeColor ?? new UnityReplacement.Color(defaultEdgeColor);
        SpawnNodes(graphData.NumberOfNodes, nodeColors);
        foreach (var (i, j) in graphData.Edges)
        {
            SpawnEdge(nodes[i], nodes[j], edgeColor);
        }
    }

    private void SpawnNodes(int quantity, IReadOnlyList<UnityReplacement.Color> colors)
    {
        nodes.Clear();
        for (var i = 0; i < quantity; i++)
        {
            var initialPosition = transform.position + Random.insideUnitSphere * transform.lossyScale.magnitude / 4;
            var node = Instantiate(nodePrefab, initialPosition, Quaternion.identity, transform);
            node.GetComponent<Renderer>().material.color = colors[i % colors.Count].ToUnityColor();
            nodes.Add(node);
        }
    }

    private static void SpawnEdge(GameObject firstNode, GameObject secondNode, UnityReplacement.Color color)
    {
        var joint = firstNode.AddComponent<SpringJoint>();
        joint.enableCollision = true;
        joint.connectedBody = secondNode.GetComponent<Rigidbody>();
        var lineRenderer = firstNode.GetComponent<LineRenderer>();
        if (lineRenderer != null)
        {
            lineRenderer.startColor = lineRenderer.endColor = color.ToUnityColor();
        }
    }
}
