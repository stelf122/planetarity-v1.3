using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class RestartClickSystem : ReactiveSystem<InputEntity>
{
    private Contexts _contexts;

    public RestartClickSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.RestartClick);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isRestartClick;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var menuManager = _contexts.game.menuManager.Value;

            menuManager.GetMenuByType(MenuType.Result).Hide();
            menuManager.GetMenuByType(MenuType.Game).Show();

            _contexts.game.CreateEntity().isCreatePlanet = true;
        }
    }
}
