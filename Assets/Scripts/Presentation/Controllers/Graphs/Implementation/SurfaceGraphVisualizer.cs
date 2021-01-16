using UnityEngine;

public class SurfaceGraphVisualizer : BaseGraphVisualizer<SurfaceGraphData>
{
    protected override void Redraw(SurfaceGraphData graphData)
    {
        var meshFilter = GetComponent<MeshFilter>();

        var mesh = new Mesh();

        int xLength = graphData.Values.GetLength(0);
        int zLength = graphData.Values.GetLength(1);
        int xLengthMinusOne = xLength - 1;
        int zLengthMinusOne = zLength - 1;
        int middleOffset = xLength * zLength;

        int vertexNumber, triangleOffset;
        int[] middleVertices = new int[4];

        Vector3[] vertices = new Vector3[xLength * zLength + xLengthMinusOne * zLengthMinusOne];
        Vector2[] uv = new Vector2[xLength * zLength + xLengthMinusOne * zLengthMinusOne];
        Vector3[] normals = new Vector3[xLength * zLength + xLengthMinusOne * zLengthMinusOne];
        int[] triangles = new int[xLengthMinusOne * zLengthMinusOne * 4 * 3];

        for (int x = 0; x < xLength; x++)
        {
            for (int z = 0; z < zLength; z++)
            {
                vertexNumber = z * xLength + x;
                vertices[vertexNumber] = new Vector3
                {
                    x = (float)x / xLengthMinusOne,
                    y = graphData.Values[x, z],
                    z = (float)z / zLengthMinusOne
                };
                vertices[vertexNumber].Scale(graphData.MetaData.Scale);
                uv[vertexNumber] = new Vector2
                {
                    x = vertices[vertexNumber].x,
                    y = vertices[vertexNumber].z
                };
                normals[vertexNumber] = Vector3.up;
            }
        }

        for (int x = 0; x < xLengthMinusOne; x++)
        {
            for (int z = 0; z < zLengthMinusOne; z++)
            {
                vertexNumber = middleOffset + z * xLengthMinusOne + x;

                vertices[vertexNumber] = new Vector3
                {
                    x = (x + 0.5f) / xLengthMinusOne,
                    y = (graphData.Values[x, z] + graphData.Values[x + 1, z] +
                    graphData.Values[x + 1, z + 1] + graphData.Values[x, z + 1]) * 0.25f,
                    z = (z + 0.5f) / zLengthMinusOne
                };
                vertices[vertexNumber].Scale(graphData.MetaData.Scale);
                uv[vertexNumber] = new Vector2
                {
                    x = vertices[vertexNumber].x,
                    y = vertices[vertexNumber].z
                };
                normals[vertexNumber] = Vector3.up;

                middleVertices[0] = z * xLength + x;
                middleVertices[1] = (z + 1) * xLength + x;
                middleVertices[2] = (z + 1) * xLength + (x + 1);
                middleVertices[3] = z * xLength + (x + 1);
                triangleOffset = (z * xLengthMinusOne + x) * 12;
                for (int i = 0; i < 4; i++)
                {
                    triangles[triangleOffset + i * 3] = vertexNumber;
                    triangles[triangleOffset + i * 3 + 1] = middleVertices[i];
                    triangles[triangleOffset + i * 3 + 2] = middleVertices[(i + 1) % 4];
                }
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;
    }
}
