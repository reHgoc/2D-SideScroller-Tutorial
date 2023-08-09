using UnityEngine;

public abstract class Enemies
{
    protected float _enemySpeed;
    protected float _enemyHealth;
    protected float _enemyShield;

    protected int _enemySize;

    protected SpriteRenderer _enemySpriteRenderer;

    protected GameObject _enemyGameObject;

    public abstract int EnemySize { get; set; }

    public abstract float EnemySpeed { get; set; }
    public abstract float EnemyHealth { get; set; }
    public abstract float EnemyShield { get; set; }

    public abstract SpriteRenderer EnemySpriteRenderer { get; set; }

    public abstract GameObject EnemyGameObject { get; set; }

    public abstract void Init();
    public abstract void Shoot();
    public abstract void Death();
    public abstract float TakeDamage();
    public abstract float SelfDamage();
    


}
