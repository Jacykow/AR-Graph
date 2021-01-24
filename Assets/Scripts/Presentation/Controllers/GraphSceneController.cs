using Assets.Scripts.BLL.Managers;
using System;
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
    public TextMeshProUGUI alertText;
    public TextMeshProUGUI communicationText;
    public Image qrScanner;

    private Dictionary<VisualisationType, Button> _visualizationTypeButtons =
        new Dictionary<VisualisationType, Button>();

    private const string GraphReadyMessage = "Wykres gotowy";
    private static TimeSpan MessageDelay = TimeSpan.FromSeconds(1.5);

    private void Start()
    {
        _visualizationTypeButtons.Add(VisualisationType.ArOnPaperCard, arOnPaperCard);
        _visualizationTypeButtons.Add(VisualisationType.ArInSpace, arInSpace);
        _visualizationTypeButtons.Add(VisualisationType.Space3D, space3D);

        _visualizationTypeButtons
            .Select(k => k.Value.OnClickAsObservable().Select(_ => k.Key)).Merge()
            .Subscribe(visualizationType =>
        {
            DataManager.Main.VisualizationTypeProperty.Value = visualizationType;
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

        DataManager.Main.VisualizationTypeProperty.Subscribe(visualizationType =>
        {
            EventSystem.current.SetSelectedGameObject(_visualizationTypeButtons[visualizationType].gameObject);
        }).AddTo(this);

        DataManager.Main.ScanningQRProperty.Where(scanning => scanning == true).Subscribe(scanning =>
        {
            DataManager.Main.VisualizationTypeProperty.Value = VisualisationType.ArOnPaperCard;
        }).AddTo(this);

        DataManager.Main.CommunicationTextProperty.Subscribe(message =>
        {
            communicationText.text = message;
        }).AddTo(this);

        DataManager.Main.GraphDataProperty.Select(_ =>
        {
            DataManager.Main.CommunicationTextProperty.Value = GraphReadyMessage;
            return Unit.Default;
        })
            .Delay(MessageDelay)
            .Subscribe(_ =>
            {
                if (DataManager.Main.CommunicationTextProperty.Value == GraphReadyMessage)
                {
                    DataManager.Main.CommunicationTextProperty.Value = "";
                }
            }).AddTo(this);

        Application.logMessageReceived += ShowError;
    }

    private void ShowError(string condition, string stackTrace, LogType type)
    {
        if (type == LogType.Error || type == LogType.Exception || type == LogType.Warning)
        {
            DataManager.Main.AlertTextProperty.Value = condition;
        }
    }
}
