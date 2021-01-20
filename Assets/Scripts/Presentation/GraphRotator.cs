using Assets.Scripts.BLL.Managers;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

public class GraphRotator : MonoBehaviour
{
    private const float rotationSpeed = 0.5f;

    private SimpleAxisVisualizer axes;
    private bool dragging = false;
    private bool canDrag = false;

    private void Awake()
    {
        axes = GetComponentInChildren<SimpleAxisVisualizer>(true);
    }

    private void Start()
    {
        DataManager.Main.VisualisationTypeProperty.Subscribe(visualizationType =>
        {
            if (visualizationType == VisualisationType.ArOnPaperCard)
            {
                canDrag = false;
            }
            else
            {
                canDrag = true;
            }
        }).AddTo(this);
    }

    private void Update()
    {
        axes.Redraw();

        if (Input.touchCount == 0)
        {
            return;
        }

        if (Input.touches[0].phase == TouchPhase.Began &&
            EventSystem.current.IsPointerOverGameObject(0) == false &&
            canDrag == true)
        {
            dragging = true;
        }

        if (Input.touches[0].phase != TouchPhase.Ended && dragging)
        {
            var delta = -Input.touches[0].deltaPosition.x;
            transform.Rotate(transform.up, rotationSpeed * delta);
            UpdatePosition();
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
