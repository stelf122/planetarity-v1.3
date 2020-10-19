using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class UpdatePlanetViewHealthSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public UpdatePlanetViewHealthSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Health);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasHealth && entity.hasPlanetView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var planetConfig = _contexts.game.planetConfig.Value;

            e.planetView.Value.SetHealth(e.health.Value, planetConfig.DefaultHealth);
        }
    }
}
