using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class UpdatePlanetViewCooldownSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public UpdatePlanetViewCooldownSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Cooldown);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCooldown && entity.hasPlanetView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var rocketConfig = _contexts.game.rocketConfig.Value;

            var rocketData = rocketConfig.GetRocket(e.rocketId.Value);

            e.planetView.Value.SetCooldown(e.cooldown.Value, rocketData.Cooldown);
        }
    }
}
