using UnityEngine;

public class MoverEnemyPlane : MonoBehaviour
{
    [SerializeField] float _speed;

    private void Update()
    {
        float newPositionX = transform.position.x - _speed * Time.deltaTime;
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
