using UnityEngine;
using System.Collections;
using Entitas;

public class TickSystem : IExecuteSystem
{
    private Contexts _contexts;

    private IGroup<GameEntity> _ticks;

    public TickSystem(Contexts contexts)
    {
        _contexts = contexts;

        _ticks = _contexts.game.GetGroup(GameMatcher.Tick);
    }

    public void Execute()
    {
        foreach (var tick in _ticks.GetEntities())
        {
            tick.Destroy();
        }

        if (!_contexts.game.isPause)
        {
            _contexts.game.CreateEntity().isTick = true;
        }
    }
}
