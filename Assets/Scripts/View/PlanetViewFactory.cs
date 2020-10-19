using UnityEngine;
using System.Collections;

public class PlanetViewFactory : MonoBehaviour
{
    [SerializeField] private Transform _content;
    [SerializeField] private GameObject _planetView;

    public PlanetView Create()
    {
        GameObject view = Instantiate(_planetView, _content);

        return view.GetComponent<PlanetView>();
    }
}
