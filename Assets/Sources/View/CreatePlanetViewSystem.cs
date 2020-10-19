using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class CreatePlanetViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public CreatePlanetViewSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Planet.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPlanet;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var planetConfig = _contexts.game.planetConfig.Value;

            var factory = _contexts.game.planetViewFactory.Value;

            var planetView = factory.Create();

            e.AddPlanetView(planetView);

            planetView.SetHealth(e.health.Value, planetConfig.DefaultHealth);
            planetView.SetMark(e.isPlayer);
        }
    }
}
