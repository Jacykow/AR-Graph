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
    public Image qrScanner;

    public EventSystem eventSystem;
    private GameObject _lastSelected;

    void Start()
    {
        DataManager.Main.VisualisationTypeDataProperty.Subscribe(data =>
        {
            Debug.Log(data?.VisualisationType);
        }).AddTo(this);

        _lastSelected = eventSystem.firstSelectedGameObject;
        arOnPaperCard.onClick.AddListener(SelectArOnPaperCard);
        arInSpace.onClick.AddListener(SelectArInSpace);
        space3D.onClick.AddListener(SelectSpaceIn3D);

        setActivityOfGameObject(scannerButton.gameObject, false);
        scannerButton.onClick.AddListener(ScanQr);

        ChangeElementsAfterQrScanning();
    }

    private void Update()
    {
        eventSystem.SetSelectedGameObject(_lastSelected);
    }

    private void setActivityOfGameObject(GameObject gObject, bool active)
    {
        gObject.SetActive(active);
    }

    public void SelectArOnPaperCard()
    {
        _lastSelected = arOnPaperCard.gameObject;
        var visualisationType = new VisualisationTypeData
        {
            VisualisationType = VisualisationType.ArOnPaperCard
        };
        DataManager.Main.VisualisationTypeDataProperty.Value = visualisationType;
    }

    public void SelectArInSpace()
    {
        _lastSelected = arInSpace.gameObject;
        var visualisationType = new VisualisationTypeData
        {
            VisualisationType = VisualisationType.ArInSpace
        };
        DataManager.Main.VisualisationTypeDataProperty.Value = visualisationType;
    }
    public void SelectSpaceIn3D()
    {
        _lastSelected = space3D.gameObject;
        var visualisationType = new VisualisationTypeData
        {
            VisualisationType = VisualisationType.Space3D
        };
        DataManager.Main.VisualisationTypeDataProperty.Value = visualisationType;
    }

    public void ScanQr()
    {
        setActivityOfGameObject(qrScanner.gameObject, true);
        setActivityOfGameObject(scannerButton.gameObject, false);

        //TODO: camera and scanning
    }

    public void ChangeElementsAfterQrScanning()
    {
        setActivityOfGameObject(qrScanner.gameObject, false);
        setActivityOfGameObject(scannerButton.gameObject, true);
    }
}
