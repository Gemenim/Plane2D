using UnityEngine;

public class Remover : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private BulletPool _bulletPool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enmey))
        {
            _enemyPool.PutEnemy(enmey);
        }
        else if (collision.TryGetComponent<Bullet>(out Bullet bullet))
        {
            _bulletPool.PutBullet(bullet);
        }    
    }
}
