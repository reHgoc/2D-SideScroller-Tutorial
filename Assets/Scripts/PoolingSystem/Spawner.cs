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

    [SerializeField] private ObjectToSpawn _bonusHeart;
    [SerializeField] private ObjectToSpawn _bonusShield;
    [SerializeField] private ObjectToSpawn _bonusDeath;

    private PoolingManager<EnemyObject> _smallEnemyPool;
    private PoolingManager<EnemyObject> _mediumEnemyPool;
    private PoolingManager<EnemyObject> _largeEnemyPool;

    private PoolingManager<BonusHP>     _healthBonusPool;
    private PoolingManager<BonusShield> _shieldBonusPool;
    private PoolingManager<BonusDeath>  _deathBonusPool;

    int waves;


    private void Start()
    {
        waves = 0;

        _largeEnemyPool = new PoolingManager<EnemyObject>(_largeEnemy.Prefab.GetComponent<EnemyObject>(),
            _largeEnemy.InitialPoolSize);
        _mediumEnemyPool = new PoolingManager<EnemyObject>(_mediumEnemy.Prefab.GetComponent<EnemyObject>(),
            _mediumEnemy.InitialPoolSize);
        _smallEnemyPool = new PoolingManager<EnemyObject>(_smallEnemy.Prefab.GetComponent<EnemyObject>(),
            _smallEnemy.InitialPoolSize);

        _healthBonusPool = new PoolingManager<BonusHP>(_bonusHeart.Prefab.GetComponent<BonusHP>(),
            _bonusHeart.InitialPoolSize);

        var BonusHP = _bonusHeart.Prefab.GetComponent<BonusHP>();
        BonusHP.Probabilitty = BonusHP.ComputeRatio(30f);

        EnemyObject.EnemyPool = _smallEnemyPool;

        StartCoroutine(Waves());
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

    private IEnumerator Waves()
    {
        while(waves < 4)
        {
            if (waves == 0)
            {
                StartCoroutine(SpawnCoroutine<EnemyObject>(
                _smallEnemy,
                _smallEnemy.Prefab.GetComponent<EnemyObject>(),
                _smallEnemyPool)
                );
            }
            else if (waves == 1)
            {
                StartCoroutine(SpawnCoroutine<EnemyObject>(
                _mediumEnemy,
                _mediumEnemy.Prefab.GetComponent<EnemyObject>(),
                _mediumEnemyPool)
                );
            }
            else if (waves == 2)
            {
                StartCoroutine(SpawnCoroutine<EnemyObject>(
                _largeEnemy,
                _largeEnemy.Prefab.GetComponent<EnemyObject>(),
                _largeEnemyPool)
                );
            }


            yield return new WaitForSeconds(10f);
        }
        




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
        waves++;
        print(waves);
    }
    

}
