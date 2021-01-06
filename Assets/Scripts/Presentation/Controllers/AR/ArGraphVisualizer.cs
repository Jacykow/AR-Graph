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
