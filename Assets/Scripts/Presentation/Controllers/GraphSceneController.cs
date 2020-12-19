using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GraphSceneController : MonoBehaviour
{
    public Button arOnPaperCard;
    public Button arInSpace;
    public Button space3D;
    public Button scannerButton;
    public Image[] qrScanner;

    void Start()
    {
        setActivityOfScannerButton(false);

        DataManager.Main.VisualisationTypeDataProperty.Subscribe(data =>
        {
            Debug.Log("ada");
        }).AddTo(this);
    }

    private void setActivityOfScannerButton(bool active)
    {
        scannerButton.gameObject.SetActive(active);
    }

    public void SelectArOnPaperCard()
    {
        GetComponent<EventSystem>().SetSelectedGameObject(null);
        //GetComponent<EventSystem>().SetSelectedGameObject(arOnPaperCard.gameObject);
        var visualisationType = new VisualisationTypeData
        {
            VisualisationType = VisualisationType.ArOnPaperCard
        };
        DataManager.Main.VisualisationTypeDataProperty.Value = visualisationType;
    }

    public void SelectArInSpace()
    {
        GetComponent<EventSystem>().SetSelectedGameObject(null);
        GetComponent<EventSystem>().SetSelectedGameObject(arInSpace.gameObject);
        var visualisationType = new VisualisationTypeData
        {
            VisualisationType = VisualisationType.ArInSpace
        };
        DataManager.Main.VisualisationTypeDataProperty.Value = visualisationType;
    }
    public void SelectSpaceIn3D()
    {
        GetComponent<EventSystem>().SetSelectedGameObject(null);
        GetComponent<EventSystem>().SetSelectedGameObject(space3D.gameObject);
        var visualisationType = new VisualisationTypeData
        {
            VisualisationType = VisualisationType.Space3D
        };
        DataManager.Main.VisualisationTypeDataProperty.Value = visualisationType;
    }
}
