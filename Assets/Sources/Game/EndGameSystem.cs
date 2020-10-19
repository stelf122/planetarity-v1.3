using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class EndGameSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    private IGroup<GameEntity> _player;
    private IGroup<GameEntity> _enemies;
    private IGroup<GameEntity> _rockets;
    private IGroup<InputEntity> _rocketInputs;

    public EndGameSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _player = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Planet, GameMatcher.Player));
        _enemies = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Planet).NoneOf(GameMatcher.Player));
        _rockets = contexts.game.GetGroup(GameMatcher.Rocket);
        _rocketInputs = contexts.input.GetGroup(InputMatcher.LaunchRocket);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Health);
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (_player.count == 0 || _player.GetSingleEntity().health.Value <= 0)
            {
                EndGame(false);
            }
            else if (_enemies.count == 0)
            {
                EndGame(true);
            }
            else
            { 
                foreach (var enemy in _enemies)
                {
                    if (enemy.health.Value > 0) return;
                }

                EndGame(true);
            }
        }
    }

    private void EndGame(bool win)
    {
        _contexts.game.menuController.Value.ShowMainMenu(win);

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
