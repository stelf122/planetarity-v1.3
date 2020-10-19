using UnityEngine;
using System.Collections;
using Entitas;

public class UpdatePlanetViewPositionSystem : IExecuteSystem
{
    private IGroup<GameEntity> _entities;

    public UpdatePlanetViewPositionSystem(Contexts contexts)
    {
        _entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Planet, GameMatcher.PlanetView));
    }

    public void Execute()
    {
        foreach (var e in _entities)
        {
            var planetPosition = e.planet.Object.transform.position;

            var screenPosition = Camera.main.WorldToScreenPoint(planetPosition);

            e.planetView.Value.SetPosition(screenPosition);
        }
    }
}
