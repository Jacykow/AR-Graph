﻿using UniRx;
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
    public Image qrScanner;

    private GameObject _lastSelected;

    private void Start()
    {
        _lastSelected = EventSystem.current.firstSelectedGameObject;

        arOnPaperCard.OnClickAsObservable().Subscribe(_ =>
       {
           _lastSelected = arOnPaperCard.gameObject;
           SetVisualisationType(VisualisationType.ArOnPaperCard);
       }).AddTo(this);

        arInSpace.OnClickAsObservable().Subscribe(_ =>
        {
            _lastSelected = arInSpace.gameObject;
            SetVisualisationType(VisualisationType.ArInSpace);
        }).AddTo(this);

        space3D.OnClickAsObservable().Subscribe(_ =>
        {
            _lastSelected = space3D.gameObject;
            SetVisualisationType(VisualisationType.Space3D);
        }).AddTo(this);

        randomChart.OnClickAsObservable().Subscribe(_ =>
        {
            DataManager.Main.LoadGraph(TestGraphVisualizationData.RandomData);
        }).AddTo(this);

        DataManager.Main.GraphDataUrlProperty.Subscribe(_ =>
        {
            ChangeElementsAfterQrScanning();
        }).AddTo(this);


        ScanQr();
        scannerButton.gameObject.SetActive(false);
        scannerButton.onClick.AddListener(ScanQr);
    }

    private void Update()
    {
        EventSystem.current.SetSelectedGameObject(_lastSelected);
    }

    public void SetVisualisationType(VisualisationType visualisation)
    {
        DataManager.Main.VisualisationTypeProperty.Value = visualisation;
    }

    public void ScanQr()
    {
        qrScanner.gameObject.SetActive(true);
        scannerButton.gameObject.SetActive(false);
    }

    public void ChangeElementsAfterQrScanning()
    {
        qrScanner.gameObject.SetActive(false);
        scannerButton.gameObject.SetActive(true);
    }
}
