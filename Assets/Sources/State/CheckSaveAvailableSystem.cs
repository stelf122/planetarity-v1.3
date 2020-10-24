using UnityEngine;
using System.Collections;
using Entitas;

public class CheckSaveAvailableSystem : IInitializeSystem
{
    private Contexts _contexts;

    public CheckSaveAvailableSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var menuManager = _contexts.game.menuManager.Value;

        var available = PlayerPrefs.HasKey("Save");

        menuManager.GetMenuByType<MainMenu>(MenuType.Main).SetContinue(available);
    }
}
