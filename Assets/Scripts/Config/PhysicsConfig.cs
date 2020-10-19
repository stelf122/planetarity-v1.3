using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "PhysicsConfig", menuName = "Config/PhysicsConfig")]
public class PhysicsConfig : ScriptableObject
{
    [SerializeField] private float _gravity;

    public float Gravity => _gravity;
}
