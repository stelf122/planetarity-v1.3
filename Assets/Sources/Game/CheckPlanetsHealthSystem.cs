﻿using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class CheckPlanetsHealthSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    private IGroup<GameEntity> _player;

    private IGroup<GameEntity> _enemies;

    public CheckPlanetsHealthSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;

        _player = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Planet, GameMatcher.Player));

        _enemies = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Planet).NoneOf(GameMatcher.Player));
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
        var menuManager = _contexts.game.menuManager.Value;

        var resultMenu = menuManager.GetMenuByType(MenuType.Result);

        var args = new ResultMenuArguments()
        {
            Win = win
        };

        resultMenu.Show(args);

        menuManager.GetMenuByType(MenuType.Game).Hide();

        _contexts.game.CreateEntity().isClearGameEntities = true;
    }
}
