using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Collider[] _colliders;

    private void Start()
    {
        IgnoreCollision();   
    }

    private void IgnoreCollision()
    {
        for (int i = 0; i < _colliders.Length; i++)
        {
            for (int j = 0; j < _colliders.Length; j++)
            {
                Physics.IgnoreCollision(_colliders[i], _colliders[j], true);
            }
        }
    }
}
