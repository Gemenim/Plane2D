using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x + _speed * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enmey))
        {
            Destroy(enmey.gameObject);
            Destroy(this.gameObject.transform.parent.gameObject);
            Destroy(this.gameObject);
            _scoreCounter.AddScore();
        }
    }

    public void SetScoreCounter(ScoreCounter scoreCounter)
    {
        _scoreCounter = scoreCounter;
    }
}