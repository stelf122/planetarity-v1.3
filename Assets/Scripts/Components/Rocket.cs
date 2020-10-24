using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
    private GameEntity _gameEntity;

    public void SetEntity(GameEntity gameEntity)
    {
        _gameEntity = gameEntity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _gameEntity.ReplaceCollision(collision.gameObject);
    }
}
