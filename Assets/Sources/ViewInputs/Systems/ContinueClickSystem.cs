using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class ContinueClickSystem : ReactiveSystem<InputEntity>
{
    private Contexts _contexts;

    public ContinueClickSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.ContinueClick);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isContinueClick;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var menuManager = _contexts.game.menuManager.Value;

            _contexts.game.CreateEntity().isLoadState = true;

            menuManager.GetMenuByType(MenuType.Game).Show();
            menuManager.GetMenuByType(MenuType.Main).Hide();
        }
    }
}
