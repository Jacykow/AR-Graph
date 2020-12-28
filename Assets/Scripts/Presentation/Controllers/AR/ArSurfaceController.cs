using GoogleARCore;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArSurfaceController : MonoBehaviour
{
    [SerializeField]
    private GameObject graphPrefab;

    private void Update()
    {
        TryPlacePrefab();
        LostTracking();
    }

    private void TryPlacePrefab()
    {
        if (Input.touchCount < 1)
        {
            return;
        }

        Debug.Log("asdf 1");
        var touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Began || EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            return;
        }
        Debug.Log("asdf 2");

        var raycastHitFlags = TrackableHitFlags.PlaneWithinPolygon |
            TrackableHitFlags.FeaturePointWithSurfaceNormal;
        if (!Frame.Raycast(touch.position.x, touch.position.y, raycastHitFlags, out TrackableHit hit))
        {
            return;
        }
        Debug.Log("asdf 3");

        var gameObject = Instantiate(graphPrefab, hit.Pose.position, hit.Pose.rotation);
        Debug.Log("asdf 4");
    }

    private void LostTracking()
    {
        if (Session.Status == SessionStatus.LostTracking && Session.LostTrackingReason != LostTrackingReason.None)
        {
            Debug.Log($"asdf tracking: {Session.LostTrackingReason}");
        }
        return;
    }
}
