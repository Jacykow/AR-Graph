using GoogleARCore;
using System.Collections.Generic;
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

        foreach (var augmentedImage in augmentedImages)
        {
            if (augmentedImage.TrackingState == TrackingState.Tracking && graphVisualizer == null)
            {
                Anchor anchor = augmentedImage.CreateAnchor(augmentedImage.CenterPose);
                graphVisualizer = Instantiate(graphPrefab, anchor.transform).GetComponent<ArGraphVisualizer>();
                graphVisualizer.Align(augmentedImage);
            }
            else if (augmentedImage.TrackingState == TrackingState.Stopped && graphVisualizer != null)
            {
                Destroy(graphVisualizer.gameObject);
            }
        }
    }
}
