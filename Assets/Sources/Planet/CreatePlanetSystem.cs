using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class CreatePlanetSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public CreatePlanetSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.CreatePlanet);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isCreatePlanet;
    }

    protected override void Execute(List<GameEntity> entities)
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

        planetObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1f);

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
