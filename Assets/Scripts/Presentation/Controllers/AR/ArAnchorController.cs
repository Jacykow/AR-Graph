using GoogleARCore;
using System.Collections.Generic;
using UnityEngine;

public class ArAnchorController : MonoBehaviour
{
    [SerializeField]
    private ArGraphVisualizer augmentedImageVisualizerPrefab;

    private List<AugmentedImage> tempAugmentedImages = new List<AugmentedImage>();
    private ArGraphVisualizer visualizer;

    public void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Session.Status != SessionStatus.Tracking)
        {
            Screen.sleepTimeout = SleepTimeout.SystemSetting;
        }
        else
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        Session.GetTrackables(tempAugmentedImages, TrackableQueryFilter.Updated);

        foreach (var image in tempAugmentedImages)
        {
            if (image.TrackingState == TrackingState.Tracking && visualizer == null)
            {
                Anchor anchor = image.CreateAnchor(image.CenterPose);
                visualizer = Instantiate(augmentedImageVisualizerPrefab, anchor.transform);
            }
            else if (image.TrackingState == TrackingState.Stopped && visualizer != null)
            {
                Destroy(visualizer.gameObject);
                visualizer = null;
            }
        }
    }
}
