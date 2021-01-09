using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VisualizationDataManager : MonoBehaviour
{
    [SerializeField] private Transform graphContainer;
    [SerializeField] private SimpleAxisVisualizer axes;

    private Dictionary<VisualisationType, string> visualizationScenes;
    private string currentVisualizationScene;

    public Transform GraphContainer => graphContainer;
    public SimpleAxisVisualizer Axes => axes;
    public static VisualizationDataManager Main { get; private set; }

    private void Awake()
    {
        Main = this;

        visualizationScenes = new Dictionary<VisualisationType, string>
        {
            { VisualisationType.ArInSpace, SceneNames.SurfaceScene },
            { VisualisationType.ArOnPaperCard, SceneNames.AnchorScene },
            { VisualisationType.Space3D, SceneNames.SpaceScene }
        };
    }

    private void Start()
    {
        SceneManager.sceneUnloaded += LoadCurrentScene;

        DataManager.Main.VisualisationTypeProperty.Subscribe(visualisationType =>
        {
            graphContainer.SetParent(transform);
            graphContainer.gameObject.SetActive(false);
            Axes.Hide();
            var previousVisualizationScene = currentVisualizationScene;
            currentVisualizationScene = visualizationScenes[visualisationType];
            if (GetActiveSceneNames().Any(sceneName => sceneName == previousVisualizationScene))
            {
                SceneManager.UnloadSceneAsync(previousVisualizationScene);
            }
            else
            {
                LoadCurrentScene();
            }
        }).AddTo(this);
    }

    private void LoadCurrentScene(Scene unloadedScene = default)
    {
        SceneManager.LoadSceneAsync(currentVisualizationScene, LoadSceneMode.Additive);
    }

    private IEnumerable<string> GetActiveSceneNames()
    {
        for (int x = 0; x < SceneManager.sceneCount; x++)
        {
            yield return SceneManager.GetSceneAt(x).name;
        }
    }
}
