using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Unique]
public class PhysicsConfigComponent : IComponent
{
    public PhysicsConfig Value;
}
