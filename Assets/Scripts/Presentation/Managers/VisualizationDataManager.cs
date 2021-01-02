using UnityEngine;

public class VisualizationDataManager : MonoBehaviour
{
    public static VisualizationDataManager Main { get; private set; }

    [SerializeField]
    private Transform graphContainer;

    public Transform GraphContainer => graphContainer;

    private void Awake()
    {
        Main = this;
    }
}
