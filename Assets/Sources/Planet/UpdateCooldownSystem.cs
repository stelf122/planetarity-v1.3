using UnityEngine;
using System.Collections;
using Entitas;

public class UpdateCooldownSystem : IExecuteSystem
{
    private IGroup<GameEntity> _entities;

    public UpdateCooldownSystem(Contexts contexts)
    {
        _entities = contexts.game.GetGroup(GameMatcher.Cooldown);
    }

    public void Execute()
    {
        foreach (var e in _entities)
        {
            if (e.cooldown.Value > 0)
            {
                e.ReplaceCooldown(e.cooldown.Value - Time.deltaTime);
            }
        }
    }
}
