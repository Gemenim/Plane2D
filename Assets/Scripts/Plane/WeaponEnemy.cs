using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private int _countBullets = 3;
    [SerializeField] private float _rateFire = 2;
    [SerializeField] private float _speedBullet = 1;

    private Queue<Bullet> bullets = new Queue<Bullet>();

    private void OnValidate()
    {
        if (_countBullets < 1)
            _countBullets = 1;

        if (_speedBullet <= 0)
            _speedBullet = 1;

        if (_rateFire <= 1)
            _rateFire = 2;
    }

    private void Start()
    {
        
    }
}
