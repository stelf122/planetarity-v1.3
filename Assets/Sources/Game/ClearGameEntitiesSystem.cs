using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class ClearGameEntitiesSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    private IGroup<GameEntity> _player;

    private IGroup<GameEntity> _enemies;

    private IGroup<GameEntity> _rockets;

    private IGroup<InputEntity> _rocketInputs;

    private IMenuManager _menuManager;

    public ClearGameEntitiesSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;

        _menuManager = _contexts.game.menuManager.Value;

        _player = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Planet, GameMatcher.Player));

        _enemies = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Planet).NoneOf(GameMatcher.Player));

        _rockets = contexts.game.GetGroup(GameMatcher.Rocket);

        _rocketInputs = contexts.input.GetGroup(InputMatcher.LaunchRocket);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ClearGameEntities);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isClearGameEntities;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            foreach (var e in _player.GetEntities())
            {
                GameObject.Destroy(e.planet.Object);
                GameObject.Destroy(e.planetView.Value.gameObject);

                e.Destroy();
            }

            foreach (var e in _enemies.GetEntities())
            {
                GameObject.Destroy(e.planet.Object);
                GameObject.Destroy(e.planetView.Value.gameObject);

                e.Destroy();
            }

            foreach (var e in _rockets.GetEntities())
            {
                GameObject.Destroy(e.rocket.Object);

                e.Destroy();
            }

            foreach (var e in _rocketInputs.GetEntities())
            {
                e.Destroy();
            }
        }
    }
}
