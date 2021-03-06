using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField] float _forcePower;
    [SerializeField] float _forcePowerMultipleIndex;

    Rigidbody _rigidbody;

    PlayerController _playerController;

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        _rigidbody= collision.gameObject.GetComponent<Rigidbody>();
        _rigidbody.AddForce(new Vector3(0, 1, 0.1f) * _forcePower * _forcePowerMultipleIndex);
        _playerController._bounced = true;
    }
}
