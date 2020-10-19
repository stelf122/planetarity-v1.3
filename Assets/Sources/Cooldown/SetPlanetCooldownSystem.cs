using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class SetPlanetCooldownSystem : ReactiveSystem<InputEntity>
{
    private Contexts _contexts;

    public SetPlanetCooldownSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
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
            var rocketConfig = _contexts.game.rocketConfig.Value;

            var sourceEntity = e.launchRocket.Source;

            var rocketData = rocketConfig.GetRocket(sourceEntity.rocketId.Value);

            sourceEntity.ReplaceCooldown(rocketData.Cooldown);
        }
    }
}
