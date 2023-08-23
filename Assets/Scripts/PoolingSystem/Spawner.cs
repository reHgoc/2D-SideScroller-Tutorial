using System.Collections;
using UnityEngine;

[System.Serializable]
public class ObjectToSpawn
{
    public GameObject Prefab;
    public int InitialPoolSize;
    public float SpawnRate;
}

public class Spawner : MonoBehaviour
{

    [SerializeField] private ObjectToSpawn _asteroid;
    [SerializeField] private ObjectToSpawn _smallEnemy;
    [SerializeField] private ObjectToSpawn _mediumEnemy;
    [SerializeField] private ObjectToSpawn _largeEnemy;

    private PoolingManager<EnemyObject> _smallEnemyPool;
    private PoolingManager<EnemyObject> _mediumEnemyPool;
    private PoolingManager<EnemyObject> _largeEnemyPool;

    private void Start()
    {

        _largeEnemyPool = new PoolingManager<EnemyObject>(_largeEnemy.Prefab.GetComponent<EnemyObject>(),
            _largeEnemy.InitialPoolSize);
        _mediumEnemyPool = new PoolingManager<EnemyObject>(_mediumEnemy.Prefab.GetComponent<EnemyObject>(),
            _mediumEnemy.InitialPoolSize);
        _smallEnemyPool = new PoolingManager<EnemyObject>(_smallEnemy.Prefab.GetComponent<EnemyObject>(),
            _smallEnemy.InitialPoolSize);

        EnemyObject.EnemyPool = _smallEnemyPool;

        StartCoroutine(SpawnCoroutine<EnemyObject>(
            _smallEnemy,
            _smallEnemy.Prefab.GetComponent<EnemyObject>(), 
            _smallEnemyPool)
            );
    }


    public T Spawn<T>(PoolingManager<T> pool)
        where T : MonoBehaviour
    {
       T obj = pool.Get();
        return obj;
    }

    public void ReleaseObject<T>(PoolingManager<T> pool, T obj)
        where T : MonoBehaviour
    {
        pool.Release(obj);
    }


    private IEnumerator SpawnCoroutine<T>(ObjectToSpawn config, T obj, PoolingManager<T> pool)
        where T : MonoBehaviour
    {
        int count = 0;

        while(count != config.InitialPoolSize)
        {
            Spawn<T>(pool);
            count++;
            yield return new WaitForSeconds(config.SpawnRate);
        }
       
    }
    

}
