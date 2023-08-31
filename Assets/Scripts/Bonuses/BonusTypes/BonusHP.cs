
public class BonusHP : BonusChanceSystem, IBonus
{
    public void BonusEffect()
    {
        _player.Health += _amount;
    }
}
