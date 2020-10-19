using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class KillRocketSystem : ReactiveSystem<GameEntity>
{
    public KillRocketSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.LifetimeCompleted);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isLifetimeCompleted && entity.hasRocket;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            GameObject.Destroy(e.rocket.Object);

            e.Destroy();
        }
    }
}
