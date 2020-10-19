using UnityEngine;
using System.Collections;
using Entitas;

public class LaunchPlayerRocketsSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _entities;

    public LaunchPlayerRocketsSystem(Contexts contexts)
    {
        _entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Planet));
        _contexts = contexts;
    }

    public void Execute()
    {
        if (_entities.count == 0) return;

        if (Input.GetMouseButtonDown(0))
        {
            _contexts.input.CreateEntity().AddLaunchRocket(_entities.GetSingleEntity());
        }
    }
}
