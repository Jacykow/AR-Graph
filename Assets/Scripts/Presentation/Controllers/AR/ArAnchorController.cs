﻿using GoogleARCore;
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
        if (graphVisualizer == null)
        {
            var augmentedImage = augmentedImages.FirstOrDefault(image => image.TrackingState == TrackingState.Tracking);
            if (augmentedImage != null)
            {
                Anchor anchor = augmentedImage.CreateAnchor(augmentedImage.CenterPose);
                graphVisualizer = Instantiate(graphPrefab, anchor.transform).GetComponent<ArGraphVisualizer>();
                graphVisualizer.Align(augmentedImage);
            }
        }
        else if (augmentedImages.Any(image => image.TrackingState == TrackingState.Stopped))
        {
            Destroy(graphVisualizer.gameObject);
        }
    }
}