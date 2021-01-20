using GoogleARCore;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArAnchorController : MonoBehaviour
{
    private const float ImageScale = 2.55f;

    [SerializeField]
    private GameObject graphContainerPrefab;

    private List<AugmentedImage> augmentedImages = new List<AugmentedImage>();
    private Transform outerGraphContainer;

    private void Update()
    {
        Session.GetTrackables(augmentedImages, TrackableQueryFilter.Updated);
        if (outerGraphContainer == null)
        {
            var augmentedImage = augmentedImages.FirstOrDefault(image => image.TrackingState == TrackingState.Tracking);
            if (augmentedImage != null)
            {
                Anchor anchor = augmentedImage.CreateAnchor(augmentedImage.CenterPose);
                outerGraphContainer = Instantiate(graphContainerPrefab, anchor.transform).transform;
                AlignContainerToAugmentedImage(augmentedImage);
            }
        }
        else if (augmentedImages.Any(image => image.TrackingState == TrackingState.Stopped))
        {
            Destroy(outerGraphContainer.gameObject);
        }
    }

    public void AlignContainerToAugmentedImage(AugmentedImage augmentedImage)
    {
        var size = Mathf.Min(augmentedImage.ExtentX, augmentedImage.ExtentZ);
        outerGraphContainer.localScale = Vector3.one * size;
        var containerTranform = VisualizationDataManager.Main.GraphContainer.transform;
        containerTranform.localPosition = Vector3.left * (ImageScale * 0.5f + 0.5f);
        containerTranform.localScale = Vector3.one * ImageScale;
        VisualizationDataManager.Main.Axes.Redraw();
    }
}
