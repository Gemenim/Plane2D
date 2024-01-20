using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MoverPlane))]
public class Weapon : MonoBehaviour
{
    [SerializeField] BulletPool _pool;
    [SerializeField] int _countBullets = 3;
    [SerializeField] float _cooldown = 3;

    private MoverPlane _moverPlane;
    private int _countShoots;

    private void Awake()
    {
        _moverPlane = GetComponent<MoverPlane>();
        _countShoots = _countBullets;
    }

    private void OnValidate()
    {
        if (_countBullets < 1)
            _countBullets = 1;

        if (_cooldown < 1)
            _cooldown = 1;
    }

    private void Start()
    {
        StartCoroutine(Recharge());
    }

    private void OnEnable()
    {
        _moverPlane.Shooting += Shoot;
    }

    private void OnDisable()
    {
        _moverPlane.Shooting -= Shoot;
    }

    private IEnumerator Recharge()
    {
        var cooldown = new WaitForSeconds(_cooldown);

        while (true)
        {
            if (_countShoots < _countBullets)
                _countShoots++;

            yield return cooldown;
        }
    }

    private void Shoot()
    {
        if (_countShoots > 0)
        {
            _countShoots--;
            Bullet bullet = _pool.GetBullet();
            bullet.transform.parent.transform.position = transform.position;
            bullet.transform.parent.rotation = transform.rotation;
            bullet.transform.position = bullet.transform.parent.transform.position;
            bullet.gameObject.SetActive(true);
        }
    }
}