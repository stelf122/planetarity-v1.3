using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "GlobalConfig", menuName = "Config/GlobalConfig")]
public class GlobalConfig : ScriptableObject
{
    [SerializeField] private RocketConfig _rocketConfig;
    [SerializeField] private PhysicsConfig _physicsConfig;
    [SerializeField] private PlanetConfig _planetConfig;

    public void Initialize(Contexts contexts)
    {
        var gameContext = contexts.game;

        gameContext.SetRocketConfig(_rocketConfig);
        gameContext.SetPhysicsConfig(_physicsConfig);
        gameContext.SetPlanetConfig(_planetConfig);
    }
}
