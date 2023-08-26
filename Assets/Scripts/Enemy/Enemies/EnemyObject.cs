using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    public static PoolingManager<EnemyObject> EnemyPool;

    Spawner _spawner;
    Enemy _enemyComponent;
    Player _player;

    [SerializeField] private float _speed;
    [SerializeField] private float _health;
    [SerializeField] private float _shield;
    [SerializeField] private float _size;

    float _enemyDeadZone;

    Vector3 _spawnPosition;

    private void Awake()
    {
        _enemyComponent = new Enemy();
        _enemyComponent.Init(_health, _shield, _size, _speed, this.gameObject);
        _enemyComponent.EnemySpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        float _enemyHeight = _enemyComponent.EnemyGameObject.transform.localScale.y;
        float _enemyWidth =  _enemyComponent.EnemyGameObject.transform.localScale.x;

        _spawnPosition = new Vector3(
            Random.Range(-Camera.main.rect.width * 3 + _enemyWidth, Camera.main.rect.width * 3 - _enemyWidth),
            Camera.main.rect.height * 9 + _enemyHeight,
            0f);
        transform.position = _spawnPosition;

        _enemyDeadZone = -Camera.main.rect.height * 2f - this.GetComponent<SpriteRenderer>().size.y;

    }

    private void Start()
    {
        _player = FindObjectOfType<Player>().GetComponent<Player>();
        _spawner = FindObjectOfType<Spawner>();
    }

    private void Update()
    {
        transform.position -= Vector3.up * _enemyComponent.EnemySpeed * Time.deltaTime;

        if(transform.position.y <= _enemyDeadZone)
        {
            Death();

        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == _player.gameObject)
        {
            Death();
        }
        if (collision.gameObject.GetComponent<Bullet>())
        {
            _enemyComponent.EnemyHealth = _enemyComponent.TakeDamage(collision.gameObject.GetComponent<Bullet>().Damage);
            if (_enemyComponent.EnemyHealth <= 0 ) 
            {
                Death();
            }
        }
    }

    public void Death()
    {
        _spawner.ReleaseObject<EnemyObject>(EnemyPool, this);
        _enemyComponent.EnemyHealth = _health;
        print(_enemyComponent.EnemyHealth);
        transform.position = _spawnPosition;
    }
}
