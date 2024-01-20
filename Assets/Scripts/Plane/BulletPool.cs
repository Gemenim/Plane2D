using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] Bullet _prefab;
    [SerializeField] Transform _container;

    private Queue<Bullet> _pool;

    private void Awake()
    {
        _pool = new Queue<Bullet>();
    }

    public Bullet GetBullet()
    {
        if (_pool.Count == 0)
        {
            var bullet = Instantiate(_prefab, transform.position, Quaternion.identity);
            var container = Instantiate(_container, transform.position, Quaternion.identity);
            bullet.transform.parent = container;
            bullet.SetScoreCounter(gameObject.GetComponent<ScoreCounter>());
            return bullet;
        }

        return _pool.Dequeue();
    }

    public void PutBullet(Bullet bullet)
    {
        _pool.Enqueue(bullet);
        bullet.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}
