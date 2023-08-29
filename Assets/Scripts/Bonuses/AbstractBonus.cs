using UnityEngine;

public abstract class AbstractBonus : BonusChanceSystem
{
    protected GameObject _bonusGameObject;

    protected float _bonusAmount;
    protected float _bonusProbabilitty;

    protected int _bonusType;

    
    public abstract void BonusEffect();

}
