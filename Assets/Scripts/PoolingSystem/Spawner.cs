using UnityEngine;

[System.Serializable]
public class ObjectToSpawn
{
    public string Name;
    public GameObject Prefab;
    public int InitialPoolSize;
}

public class Spawner : MonoBehaviour
{
    public ObjectToSpawn[] SpawnObject;
    
    private PoolingManager<EnemyObject> _smallEnemyPool;
    private PoolingManager<EnemyObject> _mediumEnemyPool;
    private PoolingManager<EnemyObject> _largeEnemyPool;


    private void Start()
    {
        _smallEnemyPool = new PoolingManager<EnemyObject>(SpawnObject[2].Prefab.GetComponent<EnemyObject>(),
            SpawnObject[2].InitialPoolSize);

        EnemyObject small = _smallEnemyPool.Get();

        small.gameObject.SetActive(true);
    }

}
