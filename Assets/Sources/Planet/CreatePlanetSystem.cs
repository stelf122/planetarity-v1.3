﻿using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class CreatePlanetSystem : ReactiveSystem<InputEntity>
{
    private Contexts _contexts;

    public CreatePlanetSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.StartGame);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isStartGame;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach(var e in entities)
        {
            CreatePlanet(new Vector2(8, 0), true);
            
            var planetConfig = _contexts.game.planetConfig.Value;

            int enemies = Random.Range(planetConfig.MinEnemies, planetConfig.MaxEnemies);

            for (int i = 0; i < enemies; i++)
            {
                CreatePlanet(new Vector2(12 + 4 * i, 0), false);
            }
        }
    }

    private void CreatePlanet(Vector2 position, bool isPlayer)
    {
        var planetConfig = _contexts.game.planetConfig.Value;
        var rocketConfig = _contexts.game.rocketConfig.Value;

        var planetPrefab = planetConfig.PlanetPrefab;

        var randomSpeed = planetConfig.GetRandomSpeed();
        int randomRocketId = rocketConfig.GetRandomId();

        var entity = _contexts.game.CreateEntity();

        GameObject planetObject = GameObject.Instantiate(planetPrefab);

        Rigidbody rigidbody = planetObject.GetComponent<Rigidbody>();

        planetObject.transform.position = new Vector3(position.x, 0, position.y);

        entity.AddHealth(planetConfig.DefaultHealth);
        entity.AddPlanet(planetObject);
        entity.AddSpeed(randomSpeed);
        entity.AddRigidbody(rigidbody);
        entity.AddCooldown(0);
        entity.AddRocketId(randomRocketId);

        entity.isPlayer = isPlayer;
    }
}
