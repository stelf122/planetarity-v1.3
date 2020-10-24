using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameClickSystem : ReactiveSystem<InputEntity>
{
    private GameContext _gameContext;

    private IMenuManager _menuManager;

    public StartGameClickSystem(Contexts contexts) : base(contexts.input)
    {
        _gameContext = contexts.game;
        _menuManager = contexts.game.menuManager.Value;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.StartGameClick);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isStartGameClick;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var gameMenu = _menuManager.GetMenuByType(MenuType.Game);
            var mainMenu = _menuManager.GetMenuByType(MenuType.Main);

            mainMenu.Hide();
            gameMenu.Show();

            _gameContext.CreateEntity().isCreatePlanet = true;
        }
    }
}
