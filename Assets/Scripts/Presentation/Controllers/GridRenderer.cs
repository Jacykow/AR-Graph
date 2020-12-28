using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class GridRenderer : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
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
