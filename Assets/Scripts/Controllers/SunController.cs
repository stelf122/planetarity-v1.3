using UnityEngine;
using System.Collections;

public class SunController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private void Start()
    {
        Contexts.sharedInstance.game.CreateEntity().AddRigidbody(_rigidbody);
    }
}
