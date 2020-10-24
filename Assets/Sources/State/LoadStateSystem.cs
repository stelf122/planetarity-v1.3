using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class LoadStateSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public LoadStateSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.LoadState);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isLoadState;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            string data = PlayerPrefs.GetString("Save");

            var stateData = JsonUtility.FromJson<StateData>(data);

            foreach (var planetData in stateData.Planets)
            {
                CreatePlanet(planetData);
            }
        }
    }

    private void CreatePlanet(PlanetData planetData)
    {
        var planetConfig = _contexts.game.planetConfig.Value;
        var rocketConfig = _contexts.game.rocketConfig.Value;

        var planetPrefab = planetConfig.PlanetPrefab;

        var randomSpeed = planetConfig.GetRandomSpeed();
        int randomRocketId = rocketConfig.GetRandomId();

        var entity = _contexts.game.CreateEntity();

        GameObject planetObject = GameObject.Instantiate(planetPrefab);

        planetObject.GetComponent<MeshRenderer>().material.color = planetData.Color;

        Rigidbody rigidbody = planetObject.GetComponent<Rigidbody>();

        planetObject.transform.position = new Vector3(planetData.Position.x, planetData.Position.y, planetData.Position.z);

        entity.AddHealth(planetData.Health);
        entity.AddPlanet(planetObject);
        entity.AddSpeed(randomSpeed);
        entity.AddRigidbody(rigidbody);
        entity.AddCooldown(0);
        entity.AddRocketId(randomRocketId);

        entity.isPlayer = planetData.IsPlayer;
    }
}
