using UnityEngine;
using System.Collections;

public class HudController : MonoBehaviour
{
    [SerializeField] private PlanetViewFactory _planetViewFactory;

    public void Initialize(Contexts contexts)
    {
        contexts.game.SetPlanetViewFactory(_planetViewFactory);
    }
}
