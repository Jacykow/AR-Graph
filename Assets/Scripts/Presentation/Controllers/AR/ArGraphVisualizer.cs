using UnityEngine;

public class ArGraphVisualizer : MonoBehaviour
{
    [SerializeField] private GameObject graphPrefab;

    private void Awake()
    {
        var containerTranform = VisualizationDataManager.Main.GraphContainer.transform;
        containerTranform.SetParent(transform);
        containerTranform.localPosition = Vector3.zero;
        containerTranform.localRotation = Quaternion.identity;
        containerTranform.localScale = Vector3.one;
        containerTranform.gameObject.SetActive(true);
        VisualizationDataManager.Main.Axes.Show();
    }
}
