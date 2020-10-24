using UnityEngine;
using System.Collections;
using Entitas;

public class RegisterMenusSystem : IInitializeSystem
{
    private IMenuManager _menuManager;

    public RegisterMenusSystem(Contexts contexts)
    {
        _menuManager = contexts.game.menuManager.Value;
    }

    public void Initialize()
    {
        BaseMenu[] menus = GameObject.FindObjectsOfType<BaseMenu>();

        foreach (var menu in menus)
        {
            _menuManager.RegisterMenu(menu);
        }
    }
}
