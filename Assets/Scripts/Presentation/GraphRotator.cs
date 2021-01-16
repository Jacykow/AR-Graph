using Assets.Scripts.BLL.Managers;
using UniRx;
using UnityEngine;

public class GraphRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;

    private SimpleAxisVisualizer axes;

    private void Awake()
    {
        axes = GetComponentInChildren<SimpleAxisVisualizer>(true);
    }

    private void Start()
    {
        DataManager.Main.GraphDataProperty.Subscribe(_ =>
        {
            UpdatePosition();
            axes.Redraw();
        }).AddTo(this);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var delta = -Input.GetAxis("Mouse X");
            transform.Rotate(transform.up, rotationSpeed * delta);
            UpdatePosition();
            axes.Redraw();
        }
    }

    private void UpdatePosition()
    {
        transform.localPosition = transform.localRotation * new Vector3(-axes.Dimensions.x, 0f, -axes.Dimensions.z) / 2f;
    }
}
