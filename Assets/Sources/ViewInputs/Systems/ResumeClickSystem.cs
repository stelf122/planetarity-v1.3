using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class ResumeClickSystem : ReactiveSystem<InputEntity>
{
    private GameContext _gameContext;

    private IMenuManager _menuManager;

    public ResumeClickSystem(Contexts contexts) : base(contexts.input)
    {
        _gameContext = contexts.game;
        _menuManager = contexts.game.menuManager.Value;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.ResumeClick);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isResumeClick;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var pauseMenu = _menuManager.GetMenuByType(MenuType.Pause);

            pauseMenu.Hide();

            _gameContext.isPause = false;
        }
    }
}
