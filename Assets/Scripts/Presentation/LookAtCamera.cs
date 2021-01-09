using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform cameraTransform;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(cameraTransform, Vector3.up);
    }
}
