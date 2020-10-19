using UnityEngine;
using System.Collections;
using Entitas;

public class LaunchAIRocketsSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _entities;

    public LaunchAIRocketsSystem(Contexts contexts)
    {
        _contexts = contexts;
        _entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Planet).NoneOf(GameMatcher.Player));
    }

    public void Execute()
    {
        foreach (var e in _entities)
        {
            if (e.cooldown.Value <= 0)
            {
                _contexts.input.CreateEntity().AddLaunchRocket(e);
            }
        }
    }
}
