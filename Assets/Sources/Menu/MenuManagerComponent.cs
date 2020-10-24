using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Unique]
public class MenuManagerComponent : IComponent
{
    public IMenuManager Value;
}
