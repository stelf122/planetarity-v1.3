using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class ClearSaveClickSystem : ReactiveSystem<InputEntity>
{
    private Contexts _contexts;

    public ClearSaveClickSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.ClearSaveClick);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isClearSaveClick;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var menuManager = _contexts.game.menuManager.Value;

            menuManager.GetMenuByType<MainMenu>(MenuType.Main).SetContinue(false);

            PlayerPrefs.DeleteAll();
        }
    }
}
