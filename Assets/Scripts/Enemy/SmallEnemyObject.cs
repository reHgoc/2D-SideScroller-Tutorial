using UnityEngine;

public class SmallEnemyObject : MonoBehaviour
{
    SmallEnemy _enemySmallComponent;

    Vector3 _spawnPosition;

    private void Awake()
    {
        _enemySmallComponent = new SmallEnemy();
        _enemySmallComponent.Init();
        _enemySmallComponent.EnemyGameObject = this.gameObject;

        float _enemyHeight = _enemySmallComponent.EnemyGameObject.transform.localScale.y;
        float _enemyWidth =  _enemySmallComponent.EnemyGameObject.transform.localScale.x;

        _spawnPosition = new Vector3(
            Random.Range(-Camera.main.rect.width * 3 + _enemyWidth, Camera.main.rect.width * 3 - _enemyWidth),
            Camera.main.rect.height * 9 + _enemyHeight,
            0f);
        transform.position = _spawnPosition;

        Debug.Log(Camera.main.rect.height);
    }

    private void Update()
    {
        transform.position -= Vector3.up * _enemySmallComponent.EnemySpeed * Time.deltaTime;
    }
}
