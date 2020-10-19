using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entitas;

public class SetAIRocketRandomDirection : ReactiveSystem<InputEntity>
{
    private IGroup<GameEntity> _player;

    public SetAIRocketRandomDirection(Contexts contexts) : base(contexts.input)
    {
        _player = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Planet, GameMatcher.Player));
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.CooldownChecked);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isCooldownChecked && entity.hasLaunchRocket && !entity.launchRocket.Source.isPlayer;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            Vector2 direction2 = new Vector2(Random.Range(-1, 1f), Random.Range(-1, 1f));

            e.AddDirection(direction2.normalized);
        }
    }
}
