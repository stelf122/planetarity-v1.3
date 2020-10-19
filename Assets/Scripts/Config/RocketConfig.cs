using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "RocketConfig", menuName = "Config/RocketConfig")]
public class RocketConfig : ScriptableObject
{
    [SerializeField] private GameObject _rocketPrefab;
    [SerializeField] private float _defaultLifetime;
    [SerializeField] private RocketData[] _rockets;

    public GameObject RocketPrefab => _rocketPrefab;
    public float DefaultLifetime => _defaultLifetime;

    public RocketData GetRocket(int id)
    {
        return _rockets[id];
    }

    public int GetRandomId()
    {
        return Random.Range(0, _rockets.Length);
    }
}

[Serializable]
public class RocketData
{
    [SerializeField] private float _cooldown;
    [SerializeField] private float _acceleration;

    public float Cooldown => _cooldown;
    public float Acceleration => _acceleration;
}
