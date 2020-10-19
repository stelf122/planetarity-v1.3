using UnityEngine;
using System.Collections;

public class RootSystems : Feature
{
    public RootSystems(Contexts contexts)
    {
        Add(new CheckRocketCooldownSystem(contexts));
        Add(new RotatePlanetSystem(contexts));
        Add(new CreatePlanetSystem(contexts));
        Add(new SetPlanetCooldownSystem(contexts));
        Add(new LaunchPlayerRocketsSystem(contexts));
        Add(new SetPlayerRocketDirectionSystem(contexts));
        Add(new CreateRocketSystem(contexts));
        Add(new GravitySystem(contexts));
        Add(new SunCollision(contexts));
        Add(new UpdateLifetimeSystem(contexts));
        Add(new KillRocketSystem(contexts));
        Add(new DealDamageSystem(contexts));
        Add(new UpdateCooldownSystem(contexts));
        Add(new LaunchAIRocketsSystem(contexts));
        Add(new DestroyPlanetSystem(contexts));
        Add(new EndGameSystem(contexts));
        //Add(new SetAIRocketDirection(contexts));
        Add(new SetAIRocketRandomDirection(contexts));
    }
}
