using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class MenuClickSystem : ReactiveSystem<InputEntity>
{
    private Contexts _contexts;

    public MenuClickSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.MenuClick);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isMenuClick;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var menuManager = _contexts.game.menuManager.Value;

            menuManager.GetMenuByType(MenuType.Game).Hide();
            menuManager.GetMenuByType(MenuType.Pause).Hide();
            menuManager.GetMenuByType(MenuType.Main).Show();

            _contexts.game.CreateEntity().isClearGameEntities = true;
            _contexts.game.isPause = false;
        }
    }
}
