using System;
using UnityEngine;

[RequireComponent(typeof(MoverPlane))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(PlaneCollisionHandler))]
public class Plane : MonoBehaviour
{
    private MoverPlane _moverPlane;
    private ScoreCounter _scoreCounter;
    private PlaneCollisionHandler _handler;

    public event Action GameOver;

    private void Awake()
    {
        _moverPlane = GetComponent<MoverPlane>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _handler = GetComponent<PlaneCollisionHandler>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        GameOver?.Invoke();
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _moverPlane.Reset();
    }
}
