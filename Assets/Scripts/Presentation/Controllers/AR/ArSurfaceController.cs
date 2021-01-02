using GoogleARCore;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArSurfaceController : MonoBehaviour
{
    [SerializeField]
    private GameObject graphPrefab;

    private ArGraphVisualizer graph;

    private void Update()
    {
        if (graph == null)
        {
            TryPlacePrefab();
        }
    }

    private void TryPlacePrefab()
    {
        if (Input.touchCount < 1)
        {
            return;
        }

        var touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Began || EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            return;
        }

        var raycastHitFlags = TrackableHitFlags.PlaneWithinPolygon |
            TrackableHitFlags.FeaturePointWithSurfaceNormal;
        if (!Frame.Raycast(touch.position.x, touch.position.y, raycastHitFlags, out TrackableHit hit))
        {
            return;
        }

        graph = Instantiate(graphPrefab, hit.Pose.position, hit.Pose.rotation).GetComponent<ArGraphVisualizer>();
    }
}
