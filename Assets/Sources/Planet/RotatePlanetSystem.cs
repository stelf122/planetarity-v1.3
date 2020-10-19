using UnityEngine;
using System.Collections;
using Entitas;

public class RotatePlanetSystem : IExecuteSystem
{
    private IGroup<GameEntity> _entities;

    public RotatePlanetSystem(Contexts contexts)
    {
        _entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Planet, GameMatcher.Speed));
    }

    public void Execute()
    {
        foreach (var e in _entities)
        {
            e.planet.Object.transform.RotateAround(Vector3.zero, Vector3.up, e.speed.Value * Time.deltaTime);
        }
    }
}
