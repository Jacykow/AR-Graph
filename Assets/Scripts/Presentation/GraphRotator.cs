using Assets.Scripts.BLL.Managers;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

public class GraphRotator : MonoBehaviour
{
    private const float rotationSpeed = 0.5f;

    private bool dragging = false;
    private bool canDrag = false;

    private void Start()
    {
        DataManager.Main.VisualisationTypeProperty.Subscribe(visualizationType =>
        {
            if (visualizationType == VisualisationType.ArOnPaperCard)
            {
                canDrag = false;
                transform.localRotation = Quaternion.identity;
                VisualizationDataManager.Main.Axes.Redraw();
                UpdatePosition();
            }
            else
            {
                canDrag = true;
            }
        }).AddTo(this);
    }

    private void Update()
    {
        VisualizationDataManager.Main.Axes.Redraw();

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
            VisualizationDataManager.Main.Axes.Redraw();
        }
        else
        {
            dragging = false;
        }
    }

    private void UpdatePosition()
    {
        transform.localPosition = transform.localRotation * new Vector3(-VisualizationDataManager.Main.Axes.Dimensions.x, 0f, -VisualizationDataManager.Main.Axes.Dimensions.z) / 2f;
    }
}
