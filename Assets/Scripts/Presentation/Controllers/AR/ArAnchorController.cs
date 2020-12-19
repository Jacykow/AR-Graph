using GoogleARCore;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArAnchorController : MonoBehaviour
{
    [SerializeField]
    private GameObject graphPrefab;

    private List<AugmentedImage> augmentedImages = new List<AugmentedImage>();
    private ArGraphVisualizer graphVisualizer;

    private void Update()
    {
        Session.GetTrackables(augmentedImages, TrackableQueryFilter.Updated);

        var augmentedImage = augmentedImages.FirstOrDefault();
        if (augmentedImage != null)
        {
            if (graphVisualizer == null && augmentedImage.TrackingState == TrackingState.Tracking)
            {
                var anchor = augmentedImage.CreateAnchor(augmentedImage.CenterPose);
                graphVisualizer = Instantiate(graphPrefab, anchor.transform).GetComponent<ArGraphVisualizer>();
                graphVisualizer.Align(augmentedImage);
            }
            else if (graphVisualizer != null && augmentedImage.TrackingState == TrackingState.Stopped)
            {
                Destroy(graphVisualizer.gameObject);
            }
        }
    }
}
