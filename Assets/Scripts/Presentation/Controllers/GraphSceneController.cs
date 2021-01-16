using System.Collections.Generic;
using System.Linq;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GraphSceneController : MonoBehaviour
{
    public Button arOnPaperCard;
    public Button arInSpace;
    public Button space3D;
    public Button randomChart;
    public Button scannerButton;
    public TextMeshProUGUI scannerButtontext;
    public Image qrScanner;

    private Dictionary<VisualisationType, Button> _visualizationTypeButtons =
        new Dictionary<VisualisationType, Button>();

    private void Start()
    {
        _visualizationTypeButtons.Add(VisualisationType.ArOnPaperCard, arOnPaperCard);
        _visualizationTypeButtons.Add(VisualisationType.ArInSpace, arInSpace);
        _visualizationTypeButtons.Add(VisualisationType.Space3D, space3D);

        _visualizationTypeButtons
            .Select(k => k.Value.OnClickAsObservable().Select(_ => k.Key)).Merge()
            .Subscribe(visualizationType =>
        {
            DataManager.Main.VisualisationTypeProperty.Value = visualizationType;
        }).AddTo(this);

        randomChart.OnClickAsObservable().Subscribe(_ =>
        {
            DataManager.Main.LoadRandomGraph();
        }).AddTo(this);

        scannerButton.OnClickAsObservable().Subscribe(_ =>
        {
            DataManager.Main.ScanningQRProperty.Value = !DataManager.Main.ScanningQRProperty.Value;
        }).AddTo(this);

        DataManager.Main.ScanningQRProperty.Subscribe(scanning =>
        {
            if (scanning)
            {
                qrScanner.gameObject.SetActive(true);
                scannerButtontext.text = "Anuluj skanowanie";
            }
            else
            {
                qrScanner.gameObject.SetActive(false);
                scannerButtontext.text = "Skanuj kod QR";
            }
        }).AddTo(this);

        DataManager.Main.VisualisationTypeProperty.Subscribe(visualizationType =>
        {
            EventSystem.current.SetSelectedGameObject(_visualizationTypeButtons[visualizationType].gameObject);
        }).AddTo(this);

        DataManager.Main.ScanningQRProperty.Where(scanning => scanning == true).Subscribe(scanning =>
        {
            DataManager.Main.VisualisationTypeProperty.Value = VisualisationType.ArOnPaperCard;
        }).AddTo(this);
    }
}
