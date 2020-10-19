using UnityEngine;
using System.Collections;
using Entitas;

public class GravitySystem : IExecuteSystem
{
    private Contexts _contexts;

    private IGroup<GameEntity> _rockets;
    private IGroup<GameEntity> _rigidbodies;

    public GravitySystem (Contexts contexts)
    {
        _contexts = contexts;

        _rockets = contexts.game.GetGroup(GameMatcher.Rocket);
        _rigidbodies = contexts.game.GetGroup(GameMatcher.Rigidbody);
    }

    public void Execute()
    {
        float gravity = _contexts.game.physicsConfig.Value.Gravity;

        foreach (var entity in _rockets)
        {
            foreach (var body in _rigidbodies)
            {
                if (entity.rigidbody == body.rigidbody) continue;

                Rigidbody target = entity.rigidbody.Value;
                Rigidbody source = body.rigidbody.Value;

                Vector3 direction = source.position - target.position;
                float distance = direction.magnitude;

                float forceMagnitude = gravity * (source.mass * target.mass) / Mathf.Pow(distance, 2);
                Vector3 force = direction.normalized * forceMagnitude;

                force = new Vector3(force.x, 0, force.z);

                target.AddForce(force);
            }
        }
    }
}
