using UnityEngine;

public class SmallEnemy : Enemies
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

    public override int EnemySize 
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

    public override void Init()
    {
        _enemyHealth = 100f;
        _enemyShield = 100f;
        _enemySize = 1;
        _enemySpeed = 3f;
       
    }

    public override void Shoot()
    {
        
    }

    public override float SelfDamage()
    {
        float damage = 5f;
        return damage;
    }
    
    public override float TakeDamage()
    {
        float damage = 5f;
        return damage;
    }

    public override void Death()
    {
       
        EnemyGameObject.SetActive(false);
    }


}
