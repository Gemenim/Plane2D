using System.Collections;
using UnityEngine;

public class EmenyGenerator : MonoBehaviour
{
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private EnemyPool _pool;

    private void Start()
    {
        StartCoroutine(GenerateEnemy());
    }

    private IEnumerator GenerateEnemy()
    {
        var wait = new WaitForSeconds(SetRandomDelay());

        while (enabled) 
        {
            Spawn();
            wait = new WaitForSeconds(SetRandomDelay());
            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
        var enemy = _pool.GetEnemy();
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    private float SetRandomDelay()
    {
        float delay = Random.Range(_minDelay, _maxDelay);
        return delay;
    }
}
