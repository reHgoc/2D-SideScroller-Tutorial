public class BonusShield : BonusChanceSystem, IBonus
{
    public void BonusEffect()
    {
        _player.ShieldEffect();
        
    }
}
