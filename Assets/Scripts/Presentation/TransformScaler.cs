using UnityEngine;

public class TransformScaler : MonoBehaviour
{
    [SerializeField] private Vector3 scaleFactor;

    public void Rescale(Transform referenceTransform)
    {
        transform.localScale = Vector3.Scale(referenceTransform.lossyScale, scaleFactor);
    }
}
