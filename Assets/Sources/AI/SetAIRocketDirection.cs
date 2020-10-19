using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class SetAIRocketDirection : ReactiveSystem<InputEntity>
{
    private IGroup<GameEntity> _player;

    public SetAIRocketDirection(Contexts contexts) : base(contexts.input)
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
            var playerEntity = _player.GetSingleEntity();

            var playerPos = playerEntity.planet.Object.transform.position;

            var planetPos = e.launchRocket.Source.planet.Object.transform.position;

            var direction = playerPos - planetPos;

            Vector2 direction2 = new Vector2(direction.x, direction.z);

            e.AddDirection(direction2.normalized);
        }
    }
}
