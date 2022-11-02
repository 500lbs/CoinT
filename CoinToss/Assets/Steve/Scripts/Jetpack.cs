using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    [Header("Shared Variables")]
    [SerializeField] private float _moveSpeed;

    [Header("Independent Variables")]
    [SerializeField] private Rigidbody _rb1;
    private Vector3 _moveInput1;
    [SerializeField] private Rigidbody _rb2;
    private Vector3 _moveInput2;

    private void Update()
    {
        CheckMove();
    }

    private void CheckMove()
    {
        // Player 1
        _moveInput1.x = Input.GetAxisRaw("Horizontal1");
        _moveInput1.z = Input.GetAxisRaw("Vertical1");
        _moveInput1.Normalize();
        _rb1.velocity = _moveInput2 * _moveSpeed;

        // Player 2
        _moveInput2.x = Input.GetAxisRaw("Horizontal2");
        _moveInput2.z = Input.GetAxisRaw("Vertical2");
        _moveInput2.Normalize();
        _rb1.velocity = _moveInput2 * _moveSpeed;
    }

}