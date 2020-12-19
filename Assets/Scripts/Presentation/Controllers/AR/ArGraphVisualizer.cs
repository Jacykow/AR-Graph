using GoogleARCore;
using UnityEngine;

public class ArGraphVisualizer : MonoBehaviour
{
    [SerializeField] private Transform graph;

    public void Align(AugmentedImage augmentedImage)
    {
        var size = Mathf.Min(augmentedImage.ExtentX, augmentedImage.ExtentZ);
        graph.localScale = Vector3.one * size;
    }
}
