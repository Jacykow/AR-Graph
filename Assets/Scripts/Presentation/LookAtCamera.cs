using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform cameraTransform;

    private void Update()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main?.transform;
        }

        transform.LookAt(cameraTransform, Vector3.up);
    }
}
