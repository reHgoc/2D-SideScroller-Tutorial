using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour 
{
    [SerializeField] private ObjectToSpawn _bulletSingle;
    //[SerializeField] private ObjectToSpawn _bulletDouble;
    //[SerializeField] private ObjectToSpawn _bulletTripple;
    //[SerializeField] private ObjectToSpawn _bulletBall;

    private PoolingManager<Bullet> _bulletSinglePool;
    private PoolingManager<Bullet> _bulletDoublePool;
    private PoolingManager<Bullet> _bulletTripplePool;
    private PoolingManager<Bullet> _bulletBallPool;

    private Spawner _spawner;

    private float _reloadTime;
    private float _shootRate;

    private float _bulletDeadZone;

    public float ReloadTime 
    {
        get { return _reloadTime; }
        set { _reloadTime = value; } 
    }

    private void Start()
    {
        _bulletSinglePool = new PoolingManager<Bullet>(_bulletSingle.Prefab.GetComponent<Bullet>(),
            _bulletSingle.InitialPoolSize);
        // _bulletDoublePool = new PoolingManager<Bullet>(_bulletDouble.Prefab.GetComponent<Bullet>(),
        //    _bulletDouble.InitialPoolSize);
        //_bulletTripplePool = new PoolingManager<Bullet>(_bulletTripple.Prefab.GetComponent<Bullet>(),
        //    _bulletTripple.InitialPoolSize);
        //_bulletBallPool = new PoolingManager<Bullet>(_bulletBall.Prefab.GetComponent<Bullet>(),
        //   _bulletBall.InitialPoolSize);

        Bullet.BulletPool = _bulletSinglePool;

        _spawner = FindObjectOfType<Spawner>();

        _bulletDeadZone = Camera.main.rect.height + 2f;
    }

    private void Update()
    {
        
        if(_shootRate > 0)
        {
            _shootRate -= Time.deltaTime;
        }
        if (Input.GetMouseButton(0) && _shootRate <= 0)
        {
            Shoot(_bulletSinglePool, _bulletSingle.SpawnRate);
        }
        _bulletSingle.Prefab.transform.position = this.transform.position;

    }

    private void Shoot(PoolingManager<Bullet> pool, float rate)
    {
        _spawner.Spawn<Bullet>(pool);
        _shootRate = rate;
        
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(_reloadTime);
    }


}
