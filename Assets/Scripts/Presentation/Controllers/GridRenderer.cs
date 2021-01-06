using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class GridRenderer : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    [SerializeField]
    [Min(0.00000001f)]
    private float scale = 2f;

    private const float DefaultInterval = 0.1f;
    private const float RescaleFactor = 5f;
    private const int MaxScaleMarks = 10;


    public float Scale
    {
        get => scale;
        set
        {
            scale = value;
            if (meshRenderer != null)
            {
                meshRenderer.material.SetFloat("_Scale", scale);
            }
        }
    }

    private void OnValidate()
    {
        Scale = scale;
    }

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        Scale = scale;

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

        transform.localPosition = primaryAxis.Direction * height / 2f + secondaryAxis.Direction * width / 2f;
        var crossProduct = Vector3.Cross(primaryAxis.Direction, secondaryAxis.Direction);
        transform.localRotation = Quaternion.LookRotation(crossProduct, primaryAxis.Direction);

        transform.localScale = new Vector3(width, height, 0f);
        meshRenderer.material.SetFloat("_GraduationScale", height);
    }

    public IEnumerable<float> GetScaleMarks()
    {
        var scaleLogFactor = Mathf.Floor(Mathf.Log10(scale));
        var normalizedScale = scale / Mathf.Pow(10f, scaleLogFactor);
        var interval = DefaultInterval;
        if (normalizedScale > RescaleFactor)
        {
            interval /= RescaleFactor;
        }

        return Enumerable.Range(0, MaxScaleMarks)
            .Select(x => x * normalizedScale * interval)
            .TakeWhile(x => x <= transform.localScale.y);
    }
}
