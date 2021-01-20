using Assets.Scripts.BLL.Managers;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

public class GraphRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;

    private SimpleAxisVisualizer axes;
    private bool dragging = false;

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
        if (Input.touchCount == 0)
        {
            return;
        }

        if (Input.touches[0].phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(0))
        {
            dragging = true;
        }

        if (Input.touches[0].phase != TouchPhase.Ended && dragging)
        {
            var delta = Input.touches[0].deltaPosition.x;
            transform.Rotate(transform.up, rotationSpeed * delta);
            UpdatePosition();
            axes.Redraw();
        }
        else
        {
            dragging = false;
        }
    }

    private void UpdatePosition()
    {
        transform.localPosition = transform.localRotation * new Vector3(-axes.Dimensions.x, 0f, -axes.Dimensions.z) / 2f;
    }
}
