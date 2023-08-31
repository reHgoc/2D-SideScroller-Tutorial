public class BonusDeath : BonusChanceSystem, IBonus
{
    public void BonusEffect()
    {
        _player.Death();
        
    }
}
