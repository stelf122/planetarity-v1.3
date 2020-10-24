using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : BaseMenu
{
    public override MenuType Type => MenuType.Main;

    [SerializeField] private Button _startButton;

    protected override void OnStart()
    {
        _startButton.onClick.AddListener(StartClick);
    }

    private void StartClick()
    {
        InputContext.CreateEntity().isStartGameClick = true;
    }
}
