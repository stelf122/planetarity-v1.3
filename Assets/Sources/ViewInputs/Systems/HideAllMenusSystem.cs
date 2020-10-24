using UnityEngine;
using System.Collections;
using Entitas;

public class HideAllMenusSystem : IInitializeSystem
{
    public HideAllMenusSystem(Contexts contexts)
    {
    }

    public void Initialize()
    {
        BaseMenu[] menus = GameObject.FindObjectsOfType<BaseMenu>();

        foreach (var menu in menus)
        {
            menu.Hide();
        }
    }
}
