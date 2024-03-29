﻿using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class RotatePlanetSystem : ReactiveSystem<GameEntity>
{
    private IGroup<GameEntity> _planets;

    public RotatePlanetSystem(Contexts contexts) : base(contexts.game)
    {
        _planets = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Planet, GameMatcher.Speed));
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
            foreach (var planetEntity in _planets)
            {
                planetEntity.planet.Object.transform.RotateAround(Vector3.zero, Vector3.up, planetEntity.speed.Value * Time.deltaTime);
            }
        }
    }
}
