using UnityEngine;
using System.Collections;

public interface IMenuManager
{
    IMenu GetMenuByType(MenuType type);

    T GetMenuByType<T>(MenuType type);

    void RegisterMenu(IMenu menu);
}
