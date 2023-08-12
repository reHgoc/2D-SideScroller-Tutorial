using UnityEngine;

public abstract class AbstractEnemies
{
    protected float _enemySpeed;
    protected float _enemyHealth;
    protected float _enemyShield;
    protected float _enemySize;

    protected SpriteRenderer _enemySpriteRenderer;

    protected GameObject _enemyGameObject;

    public abstract float EnemySize { get; set; }

    public abstract float EnemySpeed { get; set; }
    public abstract float EnemyHealth { get; set; }
    public abstract float EnemyShield { get; set; }

    public abstract SpriteRenderer EnemySpriteRenderer { get; set; }

    public abstract GameObject EnemyGameObject { get; set; }

    public abstract void Init(float health, float shield, float size, float speed, GameObject enemyGameObject);
    public abstract void Shoot();
    public abstract void Death();
    public abstract float TakeDamage();
    public abstract float SelfDamage();
    


}
