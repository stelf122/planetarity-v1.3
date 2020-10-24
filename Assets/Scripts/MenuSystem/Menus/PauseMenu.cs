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

    private void MenuClick()
    {
        throw new NotImplementedException();
    }

    private void SaveClick()
    {
        throw new NotImplementedException();
    }

    private void ResumeClick()
    {
        InputContext.CreateEntity().isResumeClick = true;
    }
}
