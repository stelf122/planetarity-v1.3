using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MainMenu : BaseMenu
{
    public override MenuType Type => MenuType.Main;

    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _clearSaveButton;

    protected override void OnStart()
    {
        _continueButton.onClick.AddListener(ContinueClick);
        _startButton.onClick.AddListener(StartClick);
        _clearSaveButton.onClick.AddListener(ClearSaveClick);
    }

    public void SetContinue(bool active)
    {
        _continueButton.interactable = active;
    }

    private void ContinueClick()
    {
        InputContext.CreateEntity().isContinueClick = true;
    }

    private void StartClick()
    {
        InputContext.CreateEntity().isStartGameClick = true;
    }

    private void ClearSaveClick()
    {
        InputContext.CreateEntity().isClearSaveClick = true;
    }
}
