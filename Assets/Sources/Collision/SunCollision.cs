using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class SunCollision : ReactiveSystem<GameEntity>
{
    public SunCollision(Contexts contexts) : base(contexts.game)
    {
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
            if (e.collision.Object.CompareTag("Sun"))
            {
                GameObject.Destroy(e.rocket.Object);

                e.Destroy();
            }
        }
    }
}
