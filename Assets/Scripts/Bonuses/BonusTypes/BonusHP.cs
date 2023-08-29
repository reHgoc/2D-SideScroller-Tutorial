
public class BonusHP : AbstractBonus
{
    private float _amount;

    public override void BonusEffect()
    {
        Player.FindObjectOfType<Player>().Health += _amount;
    }
}
