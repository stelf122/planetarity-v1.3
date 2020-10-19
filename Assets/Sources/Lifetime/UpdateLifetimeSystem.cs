using UnityEngine;
using System.Collections;
using Entitas;

public class UpdateLifetimeSystem : IExecuteSystem
{
    private IGroup<GameEntity> _entities;

    public UpdateLifetimeSystem(Contexts contexts)
    {
        _entities = contexts.game.GetGroup(GameMatcher.Lifetime);
    }

    public void Execute()
    {
        foreach (var e in _entities)
        {
            if (e.lifetime.Value > 0)
            {
                e.ReplaceLifetime(e.lifetime.Value - Time.deltaTime);
            }
            else
            {
                e.isLifetimeCompleted = true;
            }
        }
    }
}
