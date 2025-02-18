using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStageHUDControl : MonoBehaviour
{
    private StageController _stageController;

    [SerializeField] private Button _backButton;
    [SerializeField] private TMP_Text _displayNameLabel;
    private void Start()
    {
        _stageController = StageController.Instance;
        _backButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void OnEnable()
    {
        StageController.OnStageLoaded += OnStageLoaded;
    }

    private void OnDisable()
    {
        StageController.OnStageLoaded -= OnStageLoaded;

    }

    private void OnStageLoaded(Stage stage)
    {
        _backButton.interactable = _stageController.CanGoBackInHistory();
        _displayNameLabel.text = stage.DisplayName;
    }

    private void OnBackButtonClicked()
    {
        _stageController.GoBackInHistory();
    }
}
