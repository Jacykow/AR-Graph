using GoogleARCore;
using UnityEngine;

public class ArGraphVisualizer : MonoBehaviour
{
    [SerializeField] private GameObject graphPrefab;

    private const float ImageScale = 2.55f;

    public void AlignToAugmentedImage(AugmentedImage augmentedImage)
    {
        var size = Mathf.Min(augmentedImage.ExtentX, augmentedImage.ExtentZ);
        transform.localScale = Vector3.one * size;
        var containerTranform = VisualizationDataManager.Main.GraphContainer.transform;
        containerTranform.localPosition = Vector3.left * (ImageScale * 0.5f + size);
        containerTranform.localScale = Vector3.one * ImageScale;
    }

    private void Awake()
    {
        var containerTranform = VisualizationDataManager.Main.GraphContainer.transform;
        containerTranform.SetParent(transform);
        containerTranform.localPosition = Vector3.zero;
        containerTranform.localRotation = Quaternion.identity;
        containerTranform.localScale = Vector3.one;
        containerTranform.gameObject.SetActive(true);
    }
}
