using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PauseMenu : BaseMenu
{
    public override MenuType Type => MenuType.Pause;

    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _saveButton;
    [SerializeField] private Button _menuButton;

    protected override void OnStart()
    {
        _resumeButton.onClick.AddListener(ResumeClick);
        _saveButton.onClick.AddListener(SaveClick);
        _menuButton.onClick.AddListener(MenuClick);
    }

    public void SetSave(bool active)
    {
        _saveButton.interactable = active;
    }

    private void MenuClick()
    {
        InputContext.CreateEntity().isMenuClick = true;
    }

    private void SaveClick()
    {
        InputContext.CreateEntity().isSaveClick = true;
    }

    private void ResumeClick()
    {
        InputContext.CreateEntity().isResumeClick = true;
    }
}
