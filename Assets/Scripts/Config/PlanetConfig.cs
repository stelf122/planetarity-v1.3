using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "PlanetConfig", menuName = "Config/PlanetConfig")]
public class PlanetConfig : ScriptableObject
{
    [SerializeField] private GameObject _planetPrefab;
    [SerializeField] private int _minEnemies;
    [SerializeField] private int _maxEnemies;
    [SerializeField] private float _defaultHealth;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    public GameObject PlanetPrefab => _planetPrefab;
    public float DefaultHealth => _defaultHealth;
    public int MinEnemies => _minEnemies;
    public int MaxEnemies => _maxEnemies;

    public float GetRandomSpeed()
    {
        return Random.Range(_minSpeed, _maxSpeed);
    }
}
