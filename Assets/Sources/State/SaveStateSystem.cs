using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;
using System;

public class SaveStateSystem : ReactiveSystem<GameEntity>
{
    private IGroup<GameEntity> _planets;

    public SaveStateSystem(Contexts contexts) : base(contexts.game)
    {
        _planets = contexts.game.GetGroup(GameMatcher.Planet);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.SaveState);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isSaveState;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var planetsData = new List<PlanetData>();

            foreach (var planet in _planets)
            {
                planetsData.Add(new PlanetData()
                {
                    Position = planet.planet.Object.transform.position,
                    Color = planet.planet.Object.GetComponent<MeshRenderer>().material.color,
                    Health = planet.health.Value,
                    IsPlayer = planet.isPlayer
                });
            }

            var stateData = new StateData()
            {
                Planets = planetsData.ToArray()
            };

            string data = JsonUtility.ToJson(stateData);

            PlayerPrefs.SetString("Save", data);
        }
    }
}

[Serializable]
public class StateData
{
    public PlanetData[] Planets;
}

[Serializable]
public class PlanetData
{
    public Vector3 Position;
    public Color Color;
    public float Health;
    public bool IsPlayer;
}
