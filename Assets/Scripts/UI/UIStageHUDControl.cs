using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStageHUDControl : MonoBehaviour
{
    private StageController _stageController;
    [SerializeField] private Autorunner _autorunner;
    [Header("Configuration")]
    [SerializeField] private Button _backButton;
    [SerializeField] private TMP_Text _displayNameLabel;
    [SerializeField] private GameObject _loadingIndicator;
    [SerializeField] private Toggle _autorun;
    [SerializeField] private Slider _autorunSpeed;
    private void Start()
    {
        _loadingIndicator.SetActive(false);
        _stageController = StageController.Instance;
        _backButton.onClick.AddListener(OnBackButtonClicked);
        _autorun.onValueChanged.AddListener(OnAutorunToggle);
        _autorunSpeed.onValueChanged.AddListener(OnAutorunSpeedChanged);
    }

    private void OnAutorunSpeedChanged(float speed)
    {
        _autorunner.SetAutorunSpeed(Mathf.Sqrt(speed));
    }

    private void OnAutorunToggle(bool autorun)
    {
        _autorunner.SetAutorunEnabled(autorun);
        _autorunSpeed.interactable = autorun;
    }
    

    private void OnEnable()
    {
        StageController.OnStageLoaded += OnStageLoaded;
        StageController.OnLoadingStart += OnLoadingStart;
        StageController.OnLoadingComplete += OnLoadingComplete;
    }

   

    private void OnDisable()
    {
        StageController.OnStageLoaded -= OnStageLoaded;
        StageController.OnLoadingStart += OnLoadingStart;
        StageController.OnLoadingComplete += OnLoadingComplete;
    }

    private void OnLoadingStart()
    {
        _loadingIndicator.SetActive(true);
    }

    private void OnLoadingComplete()
    {
        _loadingIndicator.SetActive(false);
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
