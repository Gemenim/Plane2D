using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _container;

    private Queue<Enemy> _pool;

    private void Awake()
    {
        _pool = new Queue<Enemy>();
    }

    public Enemy GetEnemy() 
    {
        if (_pool.Count == 0)
        {
            var enemy = Instantiate(_enemy);
            enemy.transform.parent = _container;
            return enemy;
        }

        return _pool.Dequeue();
    }

    public void PutEnemy(Enemy enemy)
    {
        _pool.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }

    private void Reset()
    {
        _pool.Clear();
    }
}