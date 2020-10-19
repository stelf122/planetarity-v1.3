using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class DestroyPlanetSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public DestroyPlanetSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Health);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPlanet && entity.hasHealth;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (e.health.Value > 0) continue;

            GameObject.Destroy(e.planet.Object);
            GameObject.Destroy(e.planetView.Value.gameObject);

            e.Destroy();
        }
    }
}
