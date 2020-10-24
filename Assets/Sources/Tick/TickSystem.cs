using UnityEngine;
using System.Collections;
using Entitas;

public class TickSystem : IExecuteSystem
{
    private Contexts _contexts;

    public TickSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        if (!_contexts.game.isPause)
        {
            _contexts.game.CreateEntity().isTick = true;
        }
    }
}
