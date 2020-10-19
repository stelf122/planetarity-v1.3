using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Unique]
public class PlanetConfigComponent : IComponent
{
    public PlanetConfig Value;
}
