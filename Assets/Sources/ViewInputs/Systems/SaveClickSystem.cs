using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class SaveClickSystem : ReactiveSystem<InputEntity>
{
    private Contexts _contexts;

    public SaveClickSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.SaveClick);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isSaveClick;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var menuManager = _contexts.game.menuManager.Value;

            _contexts.game.CreateEntity().isSaveState = true;

            menuManager.GetMenuByType<PauseMenu>(MenuType.Pause).SetSave(false);
            menuManager.GetMenuByType<MainMenu>(MenuType.Main).SetContinue(true);
        }
    }
}
