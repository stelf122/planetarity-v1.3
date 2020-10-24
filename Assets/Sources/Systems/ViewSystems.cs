using UnityEngine;
using System.Collections;

public class ViewSystems : Feature
{
    public ViewSystems(Contexts contexts)
    {
        Add(new RegisterMenusSystem(contexts));
        Add(new HideAllMenusSystem(contexts));
        Add(new OpenFirstMenuSystem(contexts));
        Add(new CheckSaveAvailableSystem(contexts));
        Add(new CreatePlanetViewSystem(contexts));
        Add(new UpdatePlanetViewPositionSystem(contexts));
        Add(new UpdatePlanetViewHealthSystem(contexts));
        Add(new UpdatePlanetViewCooldownSystem(contexts));
        Add(new StartGameClickSystem(contexts));
        Add(new PauseClickSystem(contexts));
        Add(new ResumeClickSystem(contexts));
        Add(new SaveClickSystem(contexts));
        Add(new ContinueClickSystem(contexts));
        Add(new MenuClickSystem(contexts));
        Add(new ResultMenuClickSystem(contexts));
        Add(new RestartClickSystem(contexts));
        Add(new ClearSaveClickSystem(contexts));
    }
}
