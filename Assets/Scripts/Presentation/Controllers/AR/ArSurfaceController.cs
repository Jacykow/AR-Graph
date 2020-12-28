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
    }

    private void TryPlacePrefab()
    {
        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            return;
        }

        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
            TrackableHitFlags.FeaturePointWithSurfaceNormal;
        if (!Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out TrackableHit hit))
        {
            return;
        }

        var gameObject = Instantiate(graphPrefab, hit.Pose.position, hit.Pose.rotation);
    }
}
