using UnityEngine;
using System.Collections;

public class ViewSystems : Feature
{
    public ViewSystems(Contexts contexts)
    {
        Add(new CreatePlanetViewSystem(contexts));
        Add(new UpdatePlanetViewPositionSystem(contexts));
        Add(new UpdatePlanetViewHealthSystem(contexts));
        Add(new UpdatePlanetViewCooldownSystem(contexts));
    }
}
