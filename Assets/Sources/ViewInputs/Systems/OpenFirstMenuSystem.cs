using UnityEngine;
using System.Collections;
using Entitas;

public class OpenFirstMenuSystem : IInitializeSystem
{
    private IMenuManager _menuManager;

    public OpenFirstMenuSystem(Contexts contexts)
    {
        _menuManager = contexts.game.menuManager.Value;
    }

    public void Initialize()
    {
        var menu = _menuManager.GetMenuByType(MenuType.Main);

        menu.Show();
    }
}
