using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class StopRocketsSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    private IGroup<GameEntity> _rockets;

    public StopRocketsSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;

        _rockets = contexts.game.GetGroup(GameMatcher.Rocket);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Pause.AddedOrRemoved());
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        bool isPause = _contexts.game.isPause;

        if (isPause)
        {
            foreach (var e in _rockets)
            {
                e.ReplaceVelocity(e.rigidbody.Value.velocity);
                e.rigidbody.Value.velocity = Vector3.zero;
            }
        }
        else
        {
            foreach (var e in _rockets)
            {
                e.rigidbody.Value.velocity = e.velocity.Value;
            }
        }
    }
}
