﻿using GoogleARCore;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArAnchorController : MonoBehaviour
{
    private const float ImageScale = 2.55f;

    [SerializeField]
    private GameObject graphContainerPrefab;

    private List<AugmentedImage> augmentedImages = new List<AugmentedImage>();
    private Transform graphContainer;

    private void Update()
    {
        Session.GetTrackables(augmentedImages, TrackableQueryFilter.Updated);
        if (graphContainer == null)
        {
            var augmentedImage = augmentedImages.FirstOrDefault(image => image.TrackingState == TrackingState.Tracking);
            if (augmentedImage != null)
            {
                Anchor anchor = augmentedImage.CreateAnchor(augmentedImage.CenterPose);
                graphContainer = Instantiate(graphContainerPrefab, anchor.transform).transform;
                AlignContainerToAugmentedImage(augmentedImage);
            }
        }
        else if (augmentedImages.Any(image => image.TrackingState == TrackingState.Stopped))
        {
            Destroy(graphContainer.gameObject);
        }
    }

    public void AlignContainerToAugmentedImage(AugmentedImage augmentedImage)
    {
        var size = Mathf.Min(augmentedImage.ExtentX, augmentedImage.ExtentZ);
        graphContainer.localScale = Vector3.one * size;
        var containerTranform = VisualizationDataManager.Main.GraphContainer.transform;
        containerTranform.localPosition = Vector3.left * (ImageScale * 0.5f + size);
        containerTranform.localScale = Vector3.one * ImageScale;
    }
}
