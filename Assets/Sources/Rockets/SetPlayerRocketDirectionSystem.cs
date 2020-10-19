using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class SetPlayerRocketDirectionSystem : ReactiveSystem<InputEntity>
{
    private IGroup<GameEntity> _playerGroup;

    public SetPlayerRocketDirectionSystem(Contexts contexts) : base(contexts.input)
    {
        _playerGroup = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Planet));
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.CooldownChecked);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isCooldownChecked && entity.hasLaunchRocket && entity.launchRocket.Source.isPlayer;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            Vector3 planetPosition = _playerGroup.GetSingleEntity().planet.Object.transform.position;
            Vector3 planetScreenPosition = Camera.main.WorldToScreenPoint(planetPosition);

            Vector2 direction = Input.mousePosition - planetScreenPosition;

            e.AddDirection(direction.normalized);
        }
    }
}
