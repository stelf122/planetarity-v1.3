using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ResultMenuArguments
{
    public bool Win;
}

public class ResultMenu : BaseMenu
{
    public override MenuType Type => MenuType.Result;
    
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _lostPanel;

    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _menuButton;

    protected override void OnShowed(object data)
    {
        var args = (ResultMenuArguments)data;

        _winPanel.SetActive(args.Win);
        _lostPanel.SetActive(!args.Win);
    }

    protected override void OnStart()
    {
        _restartButton.onClick.AddListener(RestartClick);
        _menuButton.onClick.AddListener(MenuClick);
    }

    private void RestartClick()
    {
        InputContext.CreateEntity().isRestartClick = true;
    }

    private void MenuClick()
    {
        InputContext.CreateEntity().isResultMenuClick = true;
    }
}
