using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Unique]
public class RocketConfigComponent : IComponent
{
    public RocketConfig Value;
}
