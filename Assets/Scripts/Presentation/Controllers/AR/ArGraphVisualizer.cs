using GoogleARCore;
using UnityEngine;

public class ArGraphVisualizer : MonoBehaviour
{
    [SerializeField] private GameObject graphPrefab;

    public void AlignToAugmentedImage(AugmentedImage augmentedImage)
    {
        var size = Mathf.Min(augmentedImage.ExtentX, augmentedImage.ExtentZ);
        transform.localScale = Vector3.one * size;
    }

    private void Start()
    {
        var containerTranform = VisualizationDataManager.Main.GraphContainer.transform;
        containerTranform.position = transform.position;
        containerTranform.rotation = transform.rotation;
        containerTranform.localScale = transform.lossyScale;
    }
}
