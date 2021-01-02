using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class GridRenderer : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    //Flips the UV on the backside of the cube so it matches the front
    private void OnValidate()
    {
        var uvs = GetComponent<MeshFilter>().mesh.uv;

        uvs[6] = new Vector2(0, 0);
        uvs[7] = new Vector2(1, 0);
        uvs[10] = new Vector2(0, 1);
        uvs[11] = new Vector2(1, 1);

        GetComponent<MeshFilter>().sharedMesh.uv = uvs;
    }

    public void Redraw(IAxisProperties primaryAxis, IAxisProperties secondaryAxis)
    {
        var height = primaryAxis.Length;
        var width = secondaryAxis.Length;

        transform.position = primaryAxis.Direction * height / 2f + secondaryAxis.Direction * width / 2f;
        var crossProduct = Vector3.Cross(primaryAxis.Direction, secondaryAxis.Direction);
        transform.rotation = Quaternion.LookRotation(crossProduct, primaryAxis.Direction);

        transform.localScale = new Vector3(width, height, 0f);
        meshRenderer.material.SetFloat("_GraduationScale", height);
    }
}
