using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameMenu : BaseMenu
{
    public override MenuType Type => MenuType.Game;

    [SerializeField] private Button pauseButton;

    protected override void OnStart()
    {
        pauseButton.onClick.AddListener(PauseClick);
    }

    private void PauseClick()
    {
        InputContext.CreateEntity().isPauseClick = true;
    }
}
