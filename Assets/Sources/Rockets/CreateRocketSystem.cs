using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class CreateRocketSystem : ReactiveSystem<InputEntity>
{
    private Contexts _contexts;

    public CreateRocketSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.Direction);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasDirection && entity.hasLaunchRocket;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var rocketConfig = _contexts.game.rocketConfig.Value;

            var rocketPrefab = rocketConfig.RocketPrefab;

            var sourceEntity = e.launchRocket.Source;

            var rocketData = rocketConfig.GetRocket(sourceEntity.rocketId.Value);

            var planet = sourceEntity.planet.Object;

            Vector3 position = planet.transform.position + new Vector3(e.direction.Value.x, 0, e.direction.Value.y);
            
            GameObject rocketObject = GameObject.Instantiate(rocketPrefab, position, Quaternion.identity);

            Rigidbody rigidbody = rocketObject.GetComponent<Rigidbody>();

            var rocket = _contexts.game.CreateEntity();

            rocket.AddRocket(rocketObject);
            rocket.AddRigidbody(rigidbody);
            rocket.AddSource(e.launchRocket.Source);
            rocket.AddLifetime(rocketConfig.DefaultLifetime);

            rocketObject.GetComponent<Rocket>().SetEntity(rocket);

            rigidbody.AddForce(new Vector3(e.direction.Value.x, 0, e.direction.Value.y) * rocketData.Acceleration);
        }
    }
}
