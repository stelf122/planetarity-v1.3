using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class CheckRocketCooldownSystem : ReactiveSystem<InputEntity>
{
    public CheckRocketCooldownSystem(Contexts contexts) : base(contexts.input)
    {
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.LaunchRocket.Added());
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasLaunchRocket;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            if (e.launchRocket.Source.cooldown.Value > 0)
            {
                e.Destroy();
            }
            else
            {
                e.isCooldownChecked = true;
            }
        }
    }
}
