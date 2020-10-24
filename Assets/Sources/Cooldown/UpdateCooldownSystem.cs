using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class UpdateCooldownSystem : ReactiveSystem<GameEntity>
{
    private IGroup<GameEntity> _cooldowns;

    public UpdateCooldownSystem(Contexts contexts) : base(contexts.game)
    {
        _cooldowns = contexts.game.GetGroup(GameMatcher.Cooldown);
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
            foreach (var c in _cooldowns)
            {
                if (c.cooldown.Value > 0)
                {
                    c.ReplaceCooldown(c.cooldown.Value - Time.deltaTime);
                }
            }
        }
    }
}
