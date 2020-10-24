using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class PauseClickSystem : ReactiveSystem<InputEntity>
{
    private GameContext _gameContext;

    private IMenuManager _menuManager;

    public PauseClickSystem(Contexts contexts) : base(contexts.input)
    {
        _gameContext = contexts.game;
        _menuManager = contexts.game.menuManager.Value;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.PauseClick);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isPauseClick;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var pauseMenu = _menuManager.GetMenuByType(MenuType.Pause);

            pauseMenu.Show();

            _gameContext.isPause = true;

            _menuManager.GetMenuByType<PauseMenu>(MenuType.Pause).SetSave(true);
        }
    }
}
