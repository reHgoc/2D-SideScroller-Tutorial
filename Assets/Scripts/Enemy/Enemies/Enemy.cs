using UnityEngine;

public class Enemy : AbstractEnemies
{

    public override float EnemyHealth 
    { 
        get { return _enemyHealth; } 
        set { _enemyHealth = value; } 
    }
    public override float EnemyShield 
    { 
        get { return _enemyShield; } 
        set { _enemyShield = value; } 
    }
    public override float EnemySpeed 
    { 
        get { return _enemySpeed; } 
        set { _enemySpeed = value; } 
    }

    public override float EnemySize 
    {
        get { return _enemySize; }
        set { _enemySize = value; }
    }

    public override SpriteRenderer EnemySpriteRenderer 
    {
        get { return _enemySpriteRenderer; }
        set { _enemySpriteRenderer = value; }
    }

    public override GameObject EnemyGameObject 
    {
        get { return _enemyGameObject; }
        set { _enemyGameObject = value; }
    }

    public override void Init(float health, float shield, float size, float speed, GameObject gameObject)
    {
        _enemyHealth = health;
        _enemyShield = shield;
        _enemySize =   size;
        _enemySpeed =  speed;
        _enemyGameObject = gameObject;

        _enemyGameObject.transform.localScale = new Vector3(_enemySize,
            _enemySize,
            _enemySize);
       
    }

    public override void Shoot()
    {
        return;
    }
    
    public override float TakeDamage(float damage)
    {
        
        return _enemyHealth -= damage;
    }


}
