using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VisualizationDataManager : MonoBehaviour
{
    [SerializeField]
    private Transform graphContainer;

    private Dictionary<VisualisationType, string> visualizationScenes;
    private string currentVisualizationScene;
    private string previousVisualizationScene;

    public Transform GraphContainer => graphContainer;
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

        SceneManager.sceneUnloaded += LoadCurrentScene;
    }

    private void Start()
    {
        DataManager.Main.VisualisationTypeProperty.Subscribe(visualisationType =>
        {
            graphContainer.SetParent(transform);
            graphContainer.gameObject.SetActive(false);
            previousVisualizationScene = currentVisualizationScene;
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
