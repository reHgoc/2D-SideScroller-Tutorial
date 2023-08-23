using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static PoolingManager<Bullet> BulletPool;
    public static EnemyObject Enemy;

    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Transform _spawnPosition;

    private Spawner _spawner;

    float _bulletDeadZone;

    public float Speed 
    { 
        get { return _speed; }
        set { _speed = value; } 
    }

    public float Damage 
    {
        get { return _damage; }
        set { _damage = value; } 
    }

    public SpriteRenderer SpriteRender 
    {
        get { return _spriteRenderer; }
    }


    private void Start()
    {
        _spawner = FindObjectOfType<Spawner>().GetComponent<Spawner>();
        _spawnPosition = FindObjectOfType<Weapon>().GetComponent<Transform>();
        transform.position = _spawnPosition.position;
        _bulletDeadZone = Camera.main.rect.height * 2f + _spriteRenderer.size.y;
    }

    private void Update()
    {
        transform.position += Vector3.up * _speed * Time.deltaTime;

        if (transform.position.y >= _bulletDeadZone)
        {
            _spawner.ReleaseObject<Bullet>(BulletPool, this);
            transform.position = _spawnPosition.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D enemyColl)
    {
        if (enemyColl.gameObject.GetComponent<EnemyObject>())
        {
            _spawner.ReleaseObject<Bullet>(BulletPool, this);
        }
    }
}
