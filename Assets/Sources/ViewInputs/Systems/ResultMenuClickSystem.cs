using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class ResultMenuClickSystem : ReactiveSystem<InputEntity>
{
    private Contexts _contexts;

    public ResultMenuClickSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.ResultMenuClick);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isResultMenuClick;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var menuManager = _contexts.game.menuManager.Value;

            menuManager.GetMenuByType(MenuType.Main).Show();
            menuManager.GetMenuByType(MenuType.Result).Hide();
        }
    }
}
