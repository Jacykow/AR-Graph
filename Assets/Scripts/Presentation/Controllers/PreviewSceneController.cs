using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreviewSceneController : MonoBehaviour
{
    private Dictionary<VisualisationType, string> visualizationScenes;
    private string currentVisualizationScene;

    private void Start()
    {
        visualizationScenes = new Dictionary<VisualisationType, string>
        {
            { VisualisationType.ArInSpace, SceneNames.SurfaceScene },
            { VisualisationType.ArOnPaperCard, SceneNames.AnchorScene },
            { VisualisationType.Space3D, SceneNames.SpaceScene }
        };

        DataManager.Main.VisualisationTypeProperty.Subscribe(visualisationType =>
        {
            if (SceneManager.sceneCount > 1)
            {
                SceneManager.UnloadSceneAsync(currentVisualizationScene);
            }
            currentVisualizationScene = visualizationScenes[visualisationType];
            SceneManager.LoadScene(currentVisualizationScene, LoadSceneMode.Additive);
        }).AddTo(this);
    }
}
