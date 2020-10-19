using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Unique]
public class PlanetViewFactoryComponent : IComponent
{
    public PlanetViewFactory Value;
}
