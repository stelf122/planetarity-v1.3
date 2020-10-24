using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class LaunchPlayerRocketsSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    private IGroup<GameEntity> _players;

    public LaunchPlayerRocketsSystem(Contexts contexts) : base(contexts.game)
    {
        _players = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Planet));

        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Tick);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isTick;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (_players.count == 0) return;

            if (Input.GetMouseButtonDown(0))
            {
                _contexts.input.CreateEntity().AddLaunchRocket(_players.GetSingleEntity());
            }
        }
    }
}
