using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuManager : IMenuManager
{
    private Dictionary<MenuType, IMenu> _menus = new Dictionary<MenuType, IMenu>();

    public MenuManager(Contexts contexts)
    {
        contexts.game.SetMenuManager(this);
    }

    public IMenu GetMenuByType(MenuType type)
    {
        if (!_menus.ContainsKey(type))
        {
            Debug.LogError("Trying to get unregistered menu");
            return null;
        }

        return _menus[type];
    }

    public T GetMenuByType<T>(MenuType type)
    {
        return (T)GetMenuByType(type);
    }

    public void RegisterMenu(IMenu menu)
    {
        if (_menus.ContainsKey(menu.Type))
        {
            Debug.LogError("Trying to register menu type duplicate");
            return;
        }

        _menus.Add(menu.Type, menu);
    }
}