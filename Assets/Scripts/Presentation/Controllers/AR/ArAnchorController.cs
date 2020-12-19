using GoogleARCore;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArAnchorController : MonoBehaviour
{
    [SerializeField]
    private GameObject graphPrefab;
    [SerializeField]
    private TextMeshProUGUI debugText;

    private List<AugmentedImage> augmentedImages = new List<AugmentedImage>();
    private ArGraphVisualizer graphVisualizer;

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

        debugText.text = $"{augmentedImages.Count}\n{graphVisualizer}";
    }
}
