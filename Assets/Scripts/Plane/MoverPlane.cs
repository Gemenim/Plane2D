using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoverPlane : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Vector3 _startPosition;
    private Rigidbody2D _ridgidbody;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    public Action Shooting;

    private void Start()
    {
        _startPosition = transform.position;
        _ridgidbody = GetComponent<Rigidbody2D>();
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _ridgidbody.velocity = new Vector2(_speed, _tapForce);
            transform.rotation = _maxRotation;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shooting?.Invoke();
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _ridgidbody.velocity = Vector3.zero;
    }
}
