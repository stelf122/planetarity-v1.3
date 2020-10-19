using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class DealDamageSystem : ReactiveSystem<GameEntity>
{
    private IGroup<GameEntity> _planets;

    public DealDamageSystem(Contexts contexts) : base(contexts.game)
    {
        _planets = contexts.game.GetGroup(GameMatcher.Planet);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Collision);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCollision && entity.hasRocket;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (e.collision.Object.CompareTag("Planet"))
            {
                var planet = GetPlanet(e.collision.Object);
                var source = e.source.Entity;

                if (source != planet)
                {
                    if (source.isPlayer != planet.isPlayer)
                    {
                        planet.ReplaceHealth(planet.health.Value - 10);

                        GameObject.Destroy(e.rocket.Object);

                        e.Destroy();
                    }
                    else
                    {
                        GameObject.Destroy(e.rocket.Object);

                        e.Destroy();
                    }
                }
            }
        }
    }

    private GameEntity GetPlanet(GameObject gameObject)
    {
        foreach (var entity in _planets)
        {
            if (entity.planet.Object == gameObject)
            {
                return entity;
            }
        }

        return null;
    }
}
